using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

public class SocketServer
{
    private readonly IServerRouter _serverRouter;
    private readonly IPEndPoint _endPoint; 
    private readonly Socket _listenSocket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    private readonly byte[] _buffer = new byte[256];
    private readonly StringBuilder _stringBuilder = new();
    private readonly Logger _logger = new();
    
    public SocketServer(string address, int port, IServerRouter serverRouter)
    {
        _serverRouter = serverRouter;
        _endPoint = new IPEndPoint(IPAddress.Parse(address), port);
    }

    public void Start()
    {
        StartListening();
        
        while (true)
        {
            try
            {
                AcceptConnection();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
            }
        }
    }

    private void StartListening()
    {
        _listenSocket.Bind(_endPoint);
        _listenSocket.Listen();
        _logger.LogSuccess("Start listening");
    }

    private void AcceptConnection()
    {
        Socket connectionWithClient = _listenSocket.Accept();
        _stringBuilder.Clear();
        
        do
        {
            int bytes = connectionWithClient.Receive(_buffer);
            _stringBuilder.Append(Encoding.Unicode.GetString(_buffer, 0, bytes));
        } while (connectionWithClient.Available > 0);

        var json = _stringBuilder.ToString();
        _logger.Log(json + "\n");
        
        var command = JsonSerializer.Deserialize<CommandData>(json)!;
        _serverRouter.Route(command);

        connectionWithClient.Shutdown(SocketShutdown.Both);
        connectionWithClient.Close();
    }
}
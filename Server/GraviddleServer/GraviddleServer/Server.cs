using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

public class Server
{
    private readonly IServerRouter _serverRouter;
    private readonly IPEndPoint _endPoint; 
    private readonly Socket _listenSocket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    private readonly byte[] _buffer = new byte[256];
    private readonly StringBuilder _stringBuilder = new();
    private BinaryFormatter _binaryFormatter = new();
    
    public Server(string address, int port, IServerRouter serverRouter)
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
                Console.WriteLine(exception.Message);
            }
        }
    }

    private void StartListening()
    {
        _listenSocket.Bind(_endPoint);
        _listenSocket.Listen();
        Console.WriteLine("Start listening");
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

        Console.WriteLine(_stringBuilder);
        //_serverRouter.Route(_stringBuilder);

        connectionWithClient.Shutdown(SocketShutdown.Both);
        connectionWithClient.Close();
    }
}
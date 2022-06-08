using System.Net;
using System.Net.Sockets;

public class Client
{
    private readonly IPEndPoint _endPoint;
    private readonly SocketAsyncEventArgs _socketAsyncEventArgs = new();
    
    public Client(string address, int port)
    {
        _endPoint = new IPEndPoint(IPAddress.Parse(address), port); 
    }

    public async void Send(byte[] data)
    {
        _socketAsyncEventArgs.SetBuffer(data, 0, data.Length);

        Socket connectionWithServer = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        await connectionWithServer.ConnectAsync(_endPoint);
        connectionWithServer.SendAsync(_socketAsyncEventArgs);
        connectionWithServer.Shutdown(SocketShutdown.Both);
        connectionWithServer.Close();
    }
}
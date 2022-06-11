using System.Net;
using System.Net.Sockets;

namespace GraviddleSocketClient
{
    public class SocketClient
    {
        private readonly IPEndPoint _endPoint;
        private readonly SocketAsyncEventArgs _socketAsyncEventArgs = new SocketAsyncEventArgs();
    
        public SocketClient(string address, int port)
        {
            _endPoint = new IPEndPoint(IPAddress.Parse(address), port); 
        }

        public async void Send(byte[] data)
        {
            _socketAsyncEventArgs.SetBuffer(data, 0, data.Length);

            var connectionWithServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            await connectionWithServer.ConnectAsync(_endPoint);
            connectionWithServer.SendAsync(_socketAsyncEventArgs);
            connectionWithServer.Shutdown(SocketShutdown.Both);
            connectionWithServer.Close();
        }
    }
}
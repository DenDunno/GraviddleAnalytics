using System.Text;
using Newtonsoft.Json;

namespace GraviddleSocketClient
{
    public class GraviddleClient
    {
        private readonly SocketClient _socketClient = new SocketClient("127.0.0.1", 8080);

        public void SendDataForAnalytics(DataForAnalytics dataForAnalytics)
        {
            string serializedData = JsonConvert.SerializeObject(dataForAnalytics);
            var command = new Command(serializedData);
            string json = JsonConvert.SerializeObject(command);            
            byte[] data = Encoding.Unicode.GetBytes(json);
    
            _socketClient.Send(data);
        }
    }
}
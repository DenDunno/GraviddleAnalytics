using System.Text;
using System.Text.Json;

var graviddleClient = new Client("127.0.0.1", 8080);

while (true)
{
    string message = Console.ReadLine()!;
    
    var command = new Command(message);
    string json = JsonSerializer.Serialize(command);
    byte[] data = Encoding.Unicode.GetBytes(json);
    
    graviddleClient.Send(data);
}
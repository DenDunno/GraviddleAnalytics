
var graviddleClient = new Client("127.0.0.1", 8080);

while (true)
{
    graviddleClient.Send("нюхай бебру" + " " + DateTime.Now);
    Console.WriteLine(DateTime.Now);
    await Task.Delay(1000);
}

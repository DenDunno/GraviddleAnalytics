using GraviddleSocketClient;

var graviddleClient = new GraviddleClient();
var dataForAnalytics = new DataForAnalytics()
{
    DeviceId = "ID",
    Name = "Hanna",
    Age = 30,
    Level = 2,
    TimeForLevel = 10f,
    Stars = 2
};

while (true)
{
    dataForAnalytics.Name = Console.ReadLine()!;
    graviddleClient.SendDataForAnalytics(dataForAnalytics);
}
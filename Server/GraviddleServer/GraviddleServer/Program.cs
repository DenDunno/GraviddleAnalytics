
var database = new GraviddleDatabase();
var router = new GraviddleServerRouter(new Dictionary<CommandType, ICommand>()
{
    {CommandType.ReceiveUserData, new ReceiveUserDataCommand(database)},
    {CommandType.GetStatistics, new GetStatisticsCommand(database)}
});

var server = new SocketServer("192.168.1.105", 8080, router);

database.Open();
server.Start();
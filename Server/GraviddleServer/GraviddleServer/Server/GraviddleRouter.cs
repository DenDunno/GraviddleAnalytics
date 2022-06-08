
public class GraviddleRouter : IServerRouter
{
    private readonly IReadOnlyDictionary<CommandType, ICommandHandler> _commandHandlers = new Dictionary<CommandType, ICommandHandler>()
    {
        {CommandType.ReceiveUserData, new ReceiveUserDataCommand()},
        {CommandType.GetStatistics, new GetStatisticsCommand()},
    };
    
    public void Route(Command command)
    {
        ICommandHandler commandHandler = _commandHandlers[command.Type];
        commandHandler.Execute(command.Data);
    }
}
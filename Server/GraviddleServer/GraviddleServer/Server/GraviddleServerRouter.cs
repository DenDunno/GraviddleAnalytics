using System.Collections.ObjectModel;

public class GraviddleServerRouter : IServerRouter
{
    private readonly ReadOnlyDictionary<CommandType, ICommand> _commandHandlers;

    public GraviddleServerRouter(IDictionary<CommandType, ICommand> commandHandlers)
    {
        _commandHandlers = new ReadOnlyDictionary<CommandType, ICommand>(commandHandlers);
    }
    
    public void Route(CommandData commandData)
    {
        ICommand command = _commandHandlers[commandData.Type];
        command.Execute(commandData.Data);
    }
}
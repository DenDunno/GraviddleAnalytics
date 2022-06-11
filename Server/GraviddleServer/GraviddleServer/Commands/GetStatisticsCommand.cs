
public class GetStatisticsCommand : ICommand
{
    private readonly GraviddleDatabase _database;

    public GetStatisticsCommand(GraviddleDatabase database)
    {
        _database = database;
    }

    public void Execute(string json)
    {
    }
}
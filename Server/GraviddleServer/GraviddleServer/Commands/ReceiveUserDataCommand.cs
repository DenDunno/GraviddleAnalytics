using System.Text.Json;

public class ReceiveUserDataCommand : ICommand
{
    private readonly GraviddleDatabase _database;

    public ReceiveUserDataCommand(GraviddleDatabase database)
    {
        _database = database;
    }

    public void Execute(string json)
    {
        var dataForAnalytics = JsonSerializer.Deserialize<DataForAnalytics>(json)!;

        if (_database.RecordExists(dataForAnalytics))
        {
            _database.UpdateTime(dataForAnalytics);
        }
        else
        {
            _database.Insert(dataForAnalytics);
        }
    }
}
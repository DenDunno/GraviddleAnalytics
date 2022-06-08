
public enum CommandType
{
    ReceiveUserData = 0,
    GetStatistics = 1
}

public class Command
{
    public CommandType Type { get; set; }
    public string Data { get; set; } = null!;
}


public enum CommandType
{
}

public class Command
{
    public readonly CommandType Type;
    public readonly byte[] Data;

    public Command(CommandType type, byte[] data)
    {
        Type = type;
        Data = data;
    }
}
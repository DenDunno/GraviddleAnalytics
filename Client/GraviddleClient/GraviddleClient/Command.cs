
namespace GraviddleSocketClient
{
    public class Command
    {
        public Command(string data)
        {
            Data = data;
        }

        public int Type => 0;
        public string Data { get; }
    }
}
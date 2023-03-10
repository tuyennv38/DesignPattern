namespace CommandPattern
{
    public class Program
    {
        public static void Main()
        {
            var remote = new RemoteControl();
            var commandOff = new CommandOff();
            remote.setCommand(command: new CommandOn());
            remote.run();
        }

    }
}
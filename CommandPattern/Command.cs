namespace CommandPattern
{
    public interface Command
    {
        void execute();
    }
    public class CommandOn : Command
    {
        public void execute()
        {
            new Light().switchOn();
        }
    }
    public class CommandOff : Command
    {
        public void execute()
        {
            new Light().switchOff();
        }
    }
}

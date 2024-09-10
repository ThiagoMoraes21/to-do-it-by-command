using to_do_it_by_command.cmd;

namespace to_do_it_by_command
{
    public class Processor
    {
        private CommandFactory _commandFactory;

        public Processor()
        {
            _commandFactory = new CommandFactory();
        }

        public void Process(string task, string[] args)
        {
            var command = _commandFactory.CreateCommand(task, args);
            command.Execute();
        }
    }
}
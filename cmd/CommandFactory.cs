using to_do_it_by_command.cmd.Interfaces;

namespace to_do_it_by_command.cmd
{
    public class CommandFactory
    {

        private readonly IEnumerable<ICommand> _availableCommands =
            [
                new AddCommand()
            ];

        public ICommand CreateCommand(string commandName, string[] parameters)
        {
            var result = _availableCommands.FirstOrDefault(command => command.CommandName == commandName);
            var command = result ?? new NotFoundCommand() { CommandName = commandName };
            command.Parameters = parameters;

            return command;
        }
    }
}
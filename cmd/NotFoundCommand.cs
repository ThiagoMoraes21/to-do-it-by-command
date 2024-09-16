using to_do_it_by_command.cmd.Interfaces;

namespace to_do_it_by_command.cmd
{
    public class NotFoundCommand : ICommand
    {
        public string CommandName { get; set; } = string.Empty;
        public string[] Parameters { get; set; } = Array.Empty<string>();

        public void Execute() {
            Console.WriteLine($"\n> Could not found command: {CommandName}");
            Console.WriteLine("> Type 'help' to see the available commands and options");
        }
        
    }
}
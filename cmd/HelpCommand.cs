using to_do_it_by_command.cmd.Interfaces;

namespace to_do_it_by_command.cmd
{
    public class HelpCommand : ICommand
    {
        public string CommandName
        {
            get {
                return "help";
            }
        }

        public string[] Parameters { get; set; } = Array.Empty<string>();

        public void Execute()
        {
            var commands = new List<string>()
            {
                "> add     -> Adds a new task to the to-dos. Example: add \"new task\"",
                "> remove  -> Removes a task in the to-dos by id. Example: remove <task-id>",
                "> list    -> List tasks in the to-dos list.",
            };

            Console.WriteLine("\n\n**********************");
            Console.WriteLine("* Available Commands *");
            Console.WriteLine("**********************");

            Console.WriteLine($"\n{ string.Join("\n", commands) }");
        }
    }
}
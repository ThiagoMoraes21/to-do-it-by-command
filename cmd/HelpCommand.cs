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
                "add              -> Adds a new task to the to-dos. Example: add \"new task\"",
                "remove           -> Removes a task in the to-dos by id. Example: remove <task-id>",
                "list [options]   -> List tasks in the to-dos list.",
                " - to-do         -> List tasks with status to-do",
                " - done          -> List tasks with status done",
                " - in-progress   -> List tasks with status in-progress",
            };

            Console.WriteLine("\n\n**********************");
            Console.WriteLine("  Available Commands  ");
            Console.WriteLine("**********************");

            Console.WriteLine($"\n{ string.Join("\n", commands) }");
        }
    }
}
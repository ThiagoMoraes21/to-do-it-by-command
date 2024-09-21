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
                "add              -> Adds a new task to the to-dos.\n\n  Example: add \"new task\"\n",
                "remove           -> Removes a task in the to-dos by id.\n\n  Example: remove <task-id>\n",
                "update           -> Update a task description in the to-dos by id.\n\n  Example: update <task-id>\n",
                "mark-todo        -> Update the task status to 'to-do'.\n\n  Example: mark-todo <task-id>\n",
                "mark-done        -> Update the task status to 'done'.\n\n  Example: mark-done <task-id>\n",
                "mark-in-progress -> Update the task status to 'in-progress'.\n\n  Example: mark-in-progress <task-id>\n",
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
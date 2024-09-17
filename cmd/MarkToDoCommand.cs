using to_do_it_by_command.cmd.Interfaces;
using to_do_it_by_command.fs_tasks;
using to_do_it_by_command.fs_tasks.models;

namespace to_do_it_by_command.cmd
{
    public class MarkToDoCommand : ICommand
    {
        public string CommandName
        {
            get { return "mark-todo"; }
        }
        public string[] Parameters { get; set; } = Array.Empty<string>();
        private readonly FsJson _fsJson;

        public MarkToDoCommand(FsJson fsJson)
        {
            _fsJson = fsJson;
        }

        public void Execute()
        {
            var task = new Tasks(_fsJson);
            var newStatus = Status.Todo;
            var taskId = Parameters.First();
            var result = false;

            if(int.TryParse(taskId, out var convertedId))
            {
                result = task.UpdateTaskStatus(convertedId, newStatus);
            }

            if(!result)
            {
                Console.WriteLine("> Oh noo... Something went wrong, try again latter");
                return;
            }

            Console.WriteLine("> Task marked as to-do.");
        }
    }
}
using to_do_it_by_command.cmd.Interfaces;
using to_do_it_by_command.fs_tasks;
using to_do_it_by_command.fs_tasks.models;

namespace to_do_it_by_command.cmd
{
    public class MarkInProgressCommand : ICommand
    {
        public string CommandName
        {
            get { return "mark-in-progress"; }
        }
        public string[] Parameters { get; set; } = Array.Empty<string>();
        private readonly FsJson _fsJson;

        public MarkInProgressCommand(FsJson fsJson)
        {
            _fsJson = fsJson;
        }

        public void Execute()
        {
            var task = new Tasks(_fsJson);
            var newStatus = Status.InProgress;
            var taskId = Parameters.First();

            if(int.TryParse(taskId, out var convertedId))
            {
                task.UpdateTaskStatus(convertedId, newStatus);
                return;
            }

            Console.WriteLine("> Invalid Id ;-;");
        }
    }
}
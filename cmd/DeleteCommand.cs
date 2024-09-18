using to_do_it_by_command.cmd.Interfaces;
using to_do_it_by_command.fs_tasks;

namespace to_do_it_by_command.cmd
{
    public class DeleteCommand : ICommand
    {
        public string CommandName
        {
            get { return "delete"; }
        }
        public string[] Parameters { get; set; } = Array.Empty<string>();
        private readonly FsJson _fsJson;

        public DeleteCommand(FsJson fsJson)
        {
            _fsJson = fsJson;
        }

        public void Execute()
        {
            var task = new Tasks(_fsJson);
            var taskId = Parameters.First();

            if(int.TryParse(taskId, out var convertedId))
            {
                task.DeleteTask(convertedId);
                return;
            }

            Console.WriteLine("> Invalid Id ;-;");
        }
    }
}
using to_do_it_by_command.cmd.Interfaces;
using to_do_it_by_command.fs_tasks;

namespace to_do_it_by_command.cmd
{
    public class UpdateCommand : ICommand
    {
        public string CommandName
        {
            get { return "update"; }
        }
        public string[] Parameters { get; set; } = Array.Empty<string>();
        private readonly FsJson _fsJson;

        public UpdateCommand(FsJson fsJson)
        {
            _fsJson = fsJson;
        }

        public void Execute()
        {
            if(Parameters == null || Parameters.Length < 2)
            {
                Console.WriteLine("> Dude... you have to pass a valid Id and a non-empty description ;-;");
                return;
            }

            var task = new Tasks(_fsJson);
            var taskId = Parameters[0];
            var newDescription = Parameters[1..];

            if(int.TryParse(taskId, out var convertedId))
            {
                task.UpdateDescription(convertedId, newDescription);
            }
        }
    }
}
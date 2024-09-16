using to_do_it_by_command.cmd.Interfaces;
using to_do_it_by_command.fs_tasks;

namespace to_do_it_by_command.cmd
{
    public class AddCommand : ICommand
    {
        public string CommandName
        {
            get { return "add"; }
        }
        public string[] Parameters { get; set; } = Array.Empty<string>();
        private readonly FsJson _fsJson;

        public AddCommand(FsJson fsJson)
        {
            _fsJson = fsJson;
        }

        public void Execute()
        {
            var task = new Tasks(_fsJson);
            var description = string.Join(" ", Parameters); // TO-DO: sanitize the string
            task.AddTask(description);
        }
    }
}
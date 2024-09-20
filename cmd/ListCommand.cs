using to_do_it_by_command.cmd.Interfaces;
using to_do_it_by_command.fs_tasks;

namespace to_do_it_by_command.cmd
{
    public class ListCommand : ICommand
    {
        public string CommandName
        {
            get { return "list"; }
        }
        public string[] Parameters { get; set; } = Array.Empty<string>();
        private readonly FsJson _fsJson;

        public ListCommand(FsJson fsJson)
        {
            _fsJson = fsJson;
        }

        public void Execute()
        {
            var task = new Tasks(_fsJson);
            var filter = Parameters != null && Parameters.Length > 0 ? Parameters.First() : string.Empty;

            task.ListTasks(filter);
        }
    }
}
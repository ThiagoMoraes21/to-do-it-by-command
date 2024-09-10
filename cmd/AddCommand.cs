using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public void Execute()
        {
            Console.WriteLine($"CommandName: {CommandName}\nParameters: {string.Join(", ", Parameters)}");
            var tasks = new Tasks();

            tasks.AddTask($"{Parameters}");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace to_do_it_by_command.cmd.Interfaces
{
    public interface ICommand
    {
        string CommandName { get; }
        string[] Parameters { get; set; }
        void Execute();

    }
}
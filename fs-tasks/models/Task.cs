
using System.ComponentModel;

namespace to_do_it_by_command.fs_tasks.models
{
    public class ToDoTask
    {
       public int? Id { get; set; } 
       public string? Description { get; set; }
       public Status? Status { get; set; }
       public DateTime? CreatedAt { get; set; }
       public DateTime? UpdatedAt { get; set; }
    }

    public enum Status {
        [Description("to-do")]
        Todo,
        [Description("in-progress")]
        InProgress,
        [Description("done")]
        Done
    }
}
using to_do_it_by_command.fs_tasks.models;

namespace to_do_it_by_command.fs_tasks
{
    public class Tasks
    {
        private FsJson _fsJson;

        public Tasks(FsJson fsJson)
        {
            _fsJson = fsJson;
        }

        public void AddTask(string description)
        {
            try
            {
                var task = new ToDoTask()
                {
                    Id = GetNextId(),
                    Description = description.Trim('"'),
                    Status = Status.Todo,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                _fsJson.WriteToJsonList<ToDoTask>(task);

                Console.WriteLine("> Oh yeah... Task added successfully!");
                Console.WriteLine($"> Task ID: {task.Id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("> On noo... something went wrong, it wasn't possible to add task :(");
                Console.Write(ex);
            }
        }

        private int GetNextId()
        {
            return _fsJson.CountJsonObjects<ToDoTask>() + 1;
        }

    }
}
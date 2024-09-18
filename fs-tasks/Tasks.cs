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

                _fsJson.WriteToJsonList(task);

                Console.WriteLine("> Oh yeah... Task added successfully!");
                Console.WriteLine($"> Task ID: {task.Id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("> On noo... something went wrong, it wasn't possible to add task :(");
                Console.Write(ex);
            }
        }

        public bool UpdateTaskStatus(int id, Status newStatus)
        {
            try
            {
                var todo = new ToDoTask()
                {
                    Status = newStatus,
                    UpdatedAt = DateTime.Now
                };

                return _fsJson.FindByIdAndUpdate(id, todo);
            }
            catch (Exception ex)
            {
                Console.WriteLine("> Oh noo... something went wrong when updating the task status :(");
                Console.Write(ex);
                return false;
            }
        }

        public void UpdateDescription(int id, string[] description)
        {
            try
            {
                var newDescription = string.Join(" ", description).Trim('"');

                if (string.IsNullOrWhiteSpace(newDescription))
                {
                    Console.WriteLine("> Dude... you have to pass non-empty description ;-;");
                }

                var todo = new ToDoTask()
                {
                    Description = newDescription,
                    UpdatedAt = DateTime.Now
                };

                _fsJson.FindByIdAndUpdate(id, todo);
                Console.WriteLine("> Task updated! Now go do it !!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("> Oh noo... something went wrong when updating the task ;-;");
                Console.Write(ex);
            }
        }

        public void DeleteTask(int taskId)
        {
            try
            {
                var result = _fsJson.DeleteObjectById<ToDoTask>(taskId);
                
                if(result)
                {
                    Console.WriteLine("> Task deleted!");
                    return;
                }

                Console.WriteLine("> Wasn't possible to delete the task, verify the Id");
            }
            catch (Exception ex)
            {
                Console.WriteLine("> Oh noo... something went wrong when deleting a task ;-;");
                Console.Write(ex);
            }
        }

        private int GetNextId()
        {
            return _fsJson.CountJsonObjects<ToDoTask>() + 1;
        }

    }
}
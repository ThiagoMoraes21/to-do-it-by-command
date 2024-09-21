using to_do_it_by_command.fs_tasks.helpers;
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
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateTaskStatus(int id, Status newStatus)
        {
            try
            {
                var todo = new ToDoTask()
                {
                    Status = newStatus,
                    UpdatedAt = DateTime.Now
                };

                _fsJson.FindByIdAndUpdate(id, todo);

                var statusDescription = EnumHelper.GetEnumDescription(newStatus);
                Console.WriteLine($"> Task marked as {statusDescription}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteTask(int taskId)
        {
            try
            {
                var result = _fsJson.DeleteObjectById<ToDoTask>(taskId);

                if (result)
                {
                    Console.WriteLine("> Task deleted!");
                    return;
                }

                Console.WriteLine("> Wasn't possible to delete the task, verify the Id");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ListTasks(string status)
        {
            try
            {
                var statusOption = new FilterOptions();

                if (!string.IsNullOrEmpty(status))
                {
                    var statusValue = EnumHelper.GetEnumValueFromDescription<Status>(status);
                    statusOption.Status = statusValue;
                }
                else
                {
                    statusOption = null;
                }

                var list = _fsJson.ListObjects<ToDoTask, FilterOptions>(statusOption);

                if (list == null || list.Count() == 0)
                {
                    Console.WriteLine("> No tasks found.");
                    return;
                }

                var printList = list.Select(task =>
                {
                    var status = EnumHelper.GetEnumDescription((Status)task.Status);
                    var line = $" [{task.Id}][{task.Status}] > {task.Description}";

                    return line;
                });

                Console.WriteLine("\n** Tasks List **\n");
                Console.WriteLine(string.Join("\n", printList));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private int GetNextId()
        {
            return _fsJson.CountJsonObjects<ToDoTask>() + 1;
        }
    }

}
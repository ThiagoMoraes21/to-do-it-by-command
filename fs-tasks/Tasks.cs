using System.Text.Json;
using to_do_it_by_command.fs_tasks.models;

namespace to_do_it_by_command.fs_tasks
{
    public class Tasks
    {
        private int nextId = 0;

        public void AddTask(string description)
        {
            try
            {
                var task = new ToDoTask()
                {
                    Id = GetNextId(),
                    Description = description,
                    Status = Status.Todo,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                string fileName = "./to-dos.json"; // TO-DO: read file name from a appsettings.json 
                string jsonString = JsonSerializer.Serialize(task);

                Console.WriteLine(task);

                File.WriteAllText(fileName, jsonString);

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
            // TO-DO: read from json file and return the next available id (sequence)
            return nextId++;
        }

    }
}
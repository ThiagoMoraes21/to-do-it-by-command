
using System.Text.Json;

namespace to_do_it_by_command.fs_tasks
{
    public class FsJson
    {

        public static void WriteToJson(object obj)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string path = Path.Combine(currentDirectory, "to-dos.json");
            string jsonString = JsonSerializer.Serialize(obj);

            File.WriteAllText(path, jsonString);
        }
        
    }
}

using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;

namespace to_do_it_by_command.fs_tasks
{
    public class FsJson
    {
        private readonly FileSettings _fileSettings;

        public FsJson(IOptions<FileSettings> fileSettings)
        {
            _fileSettings = fileSettings.Value;
        }

        public void WriteToJsonList<T>(T obj)
        {
            var path = GetFilePath();
            var tasks = DeserializeJsonList<T>(path);

            tasks.Add(obj);

            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true // format a json that is human-redable
            };

            string jsonString = JsonSerializer.Serialize(tasks, options);
            File.WriteAllText(path, jsonString);
        }

        public int CountJsonObjects<T>()
        {
            var path = GetFilePath();
            var objs = DeserializeJsonList<T>(path);
            return objs.Count();
        }

        private string GetFilePath()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string path = Path.Combine(currentDirectory,
                string.Concat(_fileSettings.FileName, _fileSettings.FileType));

            return path;
        }

        private List<T> DeserializeJsonList<T>(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    string existingJson = File.ReadAllText(path);

                    // deserialize existing tasks
                    return JsonSerializer.Deserialize<List<T>>(existingJson) ?? new List<T>();
                }
                catch (JsonException ex)
                {
                    Console.WriteLine("> Error deserializing existing JSON file: " + ex.Message);
                    return new List<T>();
                }
            }

            return new List<T>();
        }

    }
}
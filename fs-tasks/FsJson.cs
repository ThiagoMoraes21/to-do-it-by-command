
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.Extensions.Options;

namespace to_do_it_by_command.fs_tasks
{
    public class FsJson
    {
        private readonly FileSettings _fileSettings;

        public FsJson(IOptions<FileSettings> fileSettings)
        {
            _fileSettings = fileSettings.Value;
        }

        public void WriteToJson(object obj)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string path = Path.Combine(currentDirectory, string.Concat(_fileSettings.FileName, _fileSettings.FileType));

            var options = new JsonSerializerOptions{
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true // format a json that is human-redable
            };

            string jsonString = JsonSerializer.Serialize(obj, options);

            File.WriteAllText(path, jsonString);
        }

    }
}
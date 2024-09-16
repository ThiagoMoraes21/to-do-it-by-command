using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Reflection;

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
            var objs = DeserializeJsonList<T>(path);

            objs.Add(obj);
            WriteToFile(path, objs);
        }

        public bool FindByIdAndUpdate<T>(int id, T obj)
        {
            var path = GetFilePath();
            var objs = DeserializeJsonList<T>(path);
            var foundObject = SearchListByProperty(objs, "Id", id);

            if (foundObject == null) return false;

            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                var newValue = property.GetValue(obj);
                var currentValue = property.GetValue(foundObject);

                if (newValue != null && !Equals(newValue, currentValue))
                {
                    property.SetValue(foundObject, newValue);
                }
            }

            Console.WriteLine($"New object: {JsonSerializer.Serialize(obj)}");

            WriteToFile(path, objs);
            return true;
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

        private void WriteToFile<T>(string path, List<T> objs)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true // format a json that is human-redable
            };

            string jsonString = JsonSerializer.Serialize(objs, options);
            File.WriteAllText(path, jsonString);
        }

        private T? SearchListByProperty<T, Y>(List<T> list, string property, Y searchValue)
        {
            return list.FirstOrDefault(obj =>
            {
                var foundProperty = typeof(T).GetProperty(property);
                if (foundProperty != null && foundProperty.PropertyType == typeof(Y))
                {
                    var value = foundProperty.GetValue(obj);

                    if(value is Y castValue)
                    {
                        return EqualityComparer<Y>.Default.Equals(castValue, searchValue);
                    }
                }
                return false;
            });
        }

    }
}
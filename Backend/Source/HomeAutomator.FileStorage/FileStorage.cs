using System.IO;
using Newtonsoft.Json;

namespace HomeAutomator.FileStorage
{
    internal class FileStorage : IFileStorage
    {
        private readonly string directory;

        public FileStorage()
        {
            this.directory = Path.Combine(Directory.GetCurrentDirectory(), "../Data");
            EnsureDataDirectoryExists();
        }

        private void EnsureDataDirectoryExists()
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public T? Read<T>(string file)
        {
            string filePath = Path.Combine(this.directory, $"{file}.json");
            if (!File.Exists(filePath))
            {
                return default(T);
            }

            string jsonResult = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(jsonResult);
        }

        public void Write<T>(T? data, string file)
        {
            string filePath = Path.Combine(this.directory, $"{file}.json");
            string jsonResult = JsonConvert.SerializeObject(data);
            File.WriteAllText(filePath, jsonResult);
        }
    }
}
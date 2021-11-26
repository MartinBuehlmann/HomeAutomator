using System;
using System.Collections.Concurrent;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace HomeAutomator.FileStorage
{
    internal class FileStorage : IFileStorage
    {
        private readonly ConcurrentDictionary<string, object> fileLocks;
        private readonly string directory;

        public FileStorage()
        {
            this.fileLocks = new ConcurrentDictionary<string, object>();
            this.directory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "../Data");
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
            lock (this.fileLocks.GetOrAdd(file, (_) => new object()))
            {
                if (!File.Exists(filePath))
                {
                    return default(T);
                }

                string jsonResult = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<T>(jsonResult);
            }
        }

        public void Write<T>(T? data, string file)
        {
            string filePath = Path.Combine(this.directory, $"{file}.json");
            lock (this.fileLocks.GetOrAdd(file, (_) => new object()))
            {
                string jsonResult = JsonConvert.SerializeObject(data);
                File.WriteAllText(filePath, jsonResult);
            }
        }

        public void Update<T>(string file, Action<T> updateAction)
            where T : new()
        {
            string filePath = Path.Combine(this.directory, $"{file}.json");
            lock (this.fileLocks.GetOrAdd(file, (_) => new object()))
            {
                var data = new T();
                if (File.Exists(filePath))
                {
                    var content = File.ReadAllText(filePath);
                    data = JsonConvert.DeserializeObject<T>(content)!;
                }

                updateAction(data);

                File.WriteAllText(filePath, JsonConvert.SerializeObject(data));
            }
        }
    }
}
namespace HomeAutomator.FileStorage;

using System;
using System.Collections.Concurrent;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

internal class FileStorage : IFileStorage
{
    private readonly string directory;
    private readonly ConcurrentDictionary<string, object> fileLocks;

    public FileStorage()
    {
        this.fileLocks = new ConcurrentDictionary<string, object>();
        this.directory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "../Data");
        this.EnsureDataDirectoryExists();
    }

    public T? Read<T>(string file)
    {
        string filePath = Path.Combine(this.directory, $"{file}.json");
        lock (this.fileLocks.GetOrAdd(file, _ => new object()))
        {
            if (!File.Exists(filePath))
            {
                return default;
            }

            string jsonResult = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(jsonResult);
        }
    }

    public void Write<T>(T? data, string file)
    {
        string filePath = Path.Combine(this.directory, $"{file}.json");
        lock (this.fileLocks.GetOrAdd(file, _ => new object()))
        {
            string jsonResult = JsonConvert.SerializeObject(data);
            File.WriteAllText(filePath, jsonResult);
        }
    }

    public void Update<T>(string file, Action<T> updateAction)
        where T : new()
    {
        string filePath = Path.Combine(this.directory, $"{file}.json");
        lock (this.fileLocks.GetOrAdd(file, _ => new object()))
        {
            var data = new T();
            if (File.Exists(filePath))
            {
                string content = File.ReadAllText(filePath);
                data = JsonConvert.DeserializeObject<T>(content)!;
            }

            updateAction(data);

            File.WriteAllText(filePath, JsonConvert.SerializeObject(data));
        }
    }

    private void EnsureDataDirectoryExists()
    {
        if (!Directory.Exists(this.directory))
        {
            Directory.CreateDirectory(this.directory);
        }
    }
}
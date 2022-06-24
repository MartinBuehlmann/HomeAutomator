namespace HomeAutomator.FileStorage
{
    using System;

    public interface IFileStorage
    {
        T? Read<T>(string file);

        void Write<T>(T? data, string file);

        void Update<T>(string file, Action<T> updateAction)
            where T : new();
    }
}
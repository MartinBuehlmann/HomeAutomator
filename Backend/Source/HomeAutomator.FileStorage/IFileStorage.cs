namespace HomeAutomator.FileStorage
{
    public interface IFileStorage
    {
        T? Read<T>(string file);

        void Write<T>(T? data, string file);
    }
}
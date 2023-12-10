namespace HomeAutomator.FileStorage;

using Microsoft.Extensions.DependencyInjection;

public static class FileStorageServiceCollectionExtensions
{
    public static IServiceCollection AddFileStorage(this IServiceCollection services)
    {
        services.AddSingleton<IFileStorage, FileStorage>();
        return services;
    }
}
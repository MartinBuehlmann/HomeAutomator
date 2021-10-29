using Microsoft.Extensions.DependencyInjection;

namespace HomeAutomator.FileStorage
{
    public static class FileStorageExtensions
    {
        public static IServiceCollection AddFileStorage(this IServiceCollection services)
        {
            services.AddTransient<IFileStorage, FileStorage>();
            return services;
        }
    }
}
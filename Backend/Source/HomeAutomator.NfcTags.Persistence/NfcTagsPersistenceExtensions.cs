using Microsoft.Extensions.DependencyInjection;

namespace HomeAutomator.NfcTags.Persistence
{
    public static class NfcTagsPersistenceExtensions
    {
        public static IServiceCollection AddNfcTagsPersistence(this IServiceCollection services)
        {
            services.AddScoped<INfcTagsRepository, NfcTagsRepository>();
            return services;
        }

    }
}
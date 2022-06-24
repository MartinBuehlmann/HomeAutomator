namespace HomeAutomator.NfcTags.Persistence
{
    using Microsoft.Extensions.DependencyInjection;

    public static class NfcTagsPersistenceServiceCollectionExtensions
    {
        public static IServiceCollection AddNfcTagsPersistence(this IServiceCollection services)
        {
            services.AddScoped<INfcTagsRepository, NfcTagsRepository>();
            return services;
        }
    }
}
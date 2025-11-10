using Microsoft.Extensions.DependencyInjection;
using BussinesLogic;

namespace APIServiceFactory
{
    public static class ServiceFactory
    {
        public static void AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ImporterLogic>();
        }
    }
}

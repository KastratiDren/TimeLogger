using TimeLogger.Application;
using TimeLogger.Infrastructure;

namespace TimeLogger.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddApplication().
                AddInfrastructure(configuration);
            
            return service;
        }
    }
}



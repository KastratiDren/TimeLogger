using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace In_Out_Manager.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddAutoMapper(typeof(DependencyInjection).Assembly);
            service.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly);
            });
            return service;
        }
    }
}

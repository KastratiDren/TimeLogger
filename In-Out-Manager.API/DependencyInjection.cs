using In_Out_Manager.Application;
using In_Out_Manager.Infrastructure;

namespace In_Out_Manager.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection service)
        {
            service.AddApplication().AddInfrastructure();
            
            return service;
        }
    }
}

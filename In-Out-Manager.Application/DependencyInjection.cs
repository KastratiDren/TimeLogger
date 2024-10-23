using Microsoft.Extensions.DependencyInjection;

namespace In_Out_Manager.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection service)
        {
            return service;
        }
    }
}

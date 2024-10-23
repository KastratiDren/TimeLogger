using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace In_Out_Manager.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomain(this IServiceCollection service)
        {
            return service;
        }
    }
}

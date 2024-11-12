using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace TimeLogger.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomain(this IServiceCollection service)
        {
            return service;
        }
    }
}

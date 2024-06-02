using dinein.Application.Common.Interfaces.Authentication;
using dinein.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace dinein.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            return services;
        }
    }
}
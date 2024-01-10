using Designer.BLL.Configurations;
using Designer.BLL.Interfaces;
using Designer.BLL.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Designer.BLL.DependencyInjection
{
    public static class DependencyExtensions
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services, JwtConfiguration config)
        {
            services.AddSingleton(config);
            services.AddScoped<JwtSecurityTokenHandler>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IAuthentificationService, AuthentificationService>();
            services.AddScoped<IProjectService, ProjectService>();
            return services;
        }
    }
}

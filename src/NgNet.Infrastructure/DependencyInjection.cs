using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NgNet.Application.Common.Interfaces;
using NgNet.Infrastructure.Identity;
using NgNet.Infrastructure.Persistence;
using NgNet.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgNet.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NgNetDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                             b => b.MigrationsAssembly(typeof(NgNetDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<NgNetDbContext>());
            services.AddDefaultIdentity<ApplicationUser>().AddEntityFrameworkStores<NgNetDbContext>();
            services.AddIdentityServer().AddApiAuthorization<ApplicationUser, NgNetDbContext>();

            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IIdentityService, IdentityService>();

            services.AddAuthentication().AddIdentityServerJwt();

            return services;
        }
    }
}

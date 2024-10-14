using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfraService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BlogDbContext>(Options =>
            Options.UseSqlite(configuration.GetConnectionString("BlogDbContext") ??
            throw new InvalidOperationException("Connectionstring blogdb not available"))
            );
            services.AddTransient<IBlogRepository, BlogRepository>();
            return services;
        }
    }
}

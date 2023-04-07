using CleanSample.Application.Interfaces;
using CleanSample.Application.Interfaces.Services;
using CleanSample.Domain.Entities;
using CleanSample.Infrastructure.Database;
using CleanSample.Infrastructure.Implementations.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanSample.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureIoC(this IServiceCollection services)
        {
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            services.AddTransient<IPlayerService, PlayerService>();

            return services;
        }

        
    }
}

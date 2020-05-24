using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Practice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Infrastructure
{
    public static class StartupSetup
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<ContosoUniversityDbContext>(options =>
                options.UseSqlServer(connectionString));
    }
}

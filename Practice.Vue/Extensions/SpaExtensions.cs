using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.Vue
{
    public static class SpaExtensions
    {
        public static IApplicationBuilder UseSpaStaticFiles(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SpaMiddleware>();
        }
    }
}

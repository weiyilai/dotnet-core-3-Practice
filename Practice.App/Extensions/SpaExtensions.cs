using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.App
{
    /// <summary>
    /// SPA 中介程序的擴充方法
    /// </summary>
    public static class SpaExtensions
    {
        /// <summary>
        /// 存取 SPA 網頁資源
        /// </summary>
        /// <param name="builder">中介程序建構器</param>
        /// <returns></returns>
        public static IApplicationBuilder UseSpaStaticFiles(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SpaMiddleware>();
        }
    }
}

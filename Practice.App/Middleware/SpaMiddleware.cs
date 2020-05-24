using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.App
{
    public class SpaMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>建構式</summary>
        public SpaMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        /// <summary>任務調用</summary>
        /// <remarks>使用 index.html 存取網頁資源</remarks>
        public async Task Invoke(HttpContext context)
        {
            await _next.Invoke(context);

            if (context.Response.StatusCode == 404 &&                       // 該資源不存在
                !System.IO.Path.HasExtension(context.Request.Path.Value) && // 網址最後沒有帶副檔名
                !context.Request.Path.Value.StartsWith("/api"))             // 網址不是 /api 開頭（不是發送 API 需求）
            {
                context.Request.Path = "/index.html";                       // 將網址改成 /index.html
                context.Response.StatusCode = 200;                          // 並將 HTTP 狀態碼修改為 200 成功

                await _next.Invoke(context);
            }
        }
    }
}

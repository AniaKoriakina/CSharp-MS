using Core.TraceIdLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.TraceIdLogic
{
    public class TraceIdMiddleware
    {
        private readonly RequestDelegate _next;

        public TraceIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, ITraceIdAccessor traceIdAccessor)
        {
            var traceId = traceIdAccessor.GetValue();
            httpContext.Response.OnStarting(() =>
            {
                if (string.IsNullOrEmpty(traceId))
                {
                    traceId = Guid.NewGuid().ToString();
                }
                if (!httpContext.Response.Headers.ContainsKey("TraceId"))
                {
                    httpContext.Response.Headers.Add("TraceId", traceId.ToString());
                }
                return Task.CompletedTask;
            });

            traceIdAccessor.WriteValue(traceId);

            await _next(httpContext);
        }
    }

}

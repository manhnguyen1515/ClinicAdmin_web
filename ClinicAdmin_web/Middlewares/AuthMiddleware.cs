using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAdmin_web.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async System.Threading.Tasks.Task Invoke(HttpContext context)
        {
            // Redirect to login if user is not authenticated. This instruction is neccessary for JS async calls, otherwise everycall will return unauthorized without explaining why
            if ((context.User.Identity.IsAuthenticated == false) && (context.Request.Path.Value != "/Account/Login"))
            {
                context.Response.Redirect("/Account/Login");
            }
            
            // Move forward into the pipeline
            await _next(context);
        }
    }
}

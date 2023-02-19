using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Automatonymous;
using Microsoft.AspNetCore.Http;

namespace FunDooApplication.Middleware
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate requestDelegate;
        public CustomExceptionMiddleware(RequestDelegate requestDelegate)
        {
            this.requestDelegate = requestDelegate;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await requestDelegate(httpContext);
            }
            catch (Exception ex)
            {
                var response = httpContext.Response;
                response.ContentType = "application/json";
                switch (ex)
                {
                    case KeyNotFoundException keyNotFound:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case UnauthorizedAccessException unauthorizedAccessException:
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        break;
                    //case BadRequestException badRequestException:
                    //    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    //    break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
            }
        }
    }
}
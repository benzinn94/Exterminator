using System;
using System.Collections.Generic;
using System.Net;
using Exterminator.Models;
using Exterminator.Models.Exceptions;
using Exterminator.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Exterminator.WebApi.ExceptionHandlerExtensions
{
    public static class ExceptionHandlerExtensions
    {
        public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(errorMsg =>
            {
                errorMsg.Run(async context => 
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

                    

                    if(exceptionHandlerFeature != null) {
                        var exceptionType = exceptionHandlerFeature.Error;
                        var statusCode = (int) HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "application/json";

                        if(exceptionType is ResourceNotFoundException) {
                            statusCode = (int) HttpStatusCode.NotFound;
                        } else if (exceptionType is ModelFormatException) {
                            statusCode = (int) HttpStatusCode.PreconditionFailed;
                        } else if (exceptionType is ArgumentOutOfRangeException) {
                            statusCode = (int) HttpStatusCode.BadRequest;
                        }

                        ExceptionModel exceptionModel = new ExceptionModel{
                            StatusCode = statusCode,
                            ExceptionMessage = exceptionType.Message,
                            StackTrace = exceptionType.StackTrace.ToString()
                        };

                        var logService = app.ApplicationServices.GetService(typeof(ILogService)) as ILogService;
                        logService.LogToDatabase(exceptionModel);

                        await context.Response.WriteAsync(new ExceptionModel{
                            StatusCode = statusCode,
                            ExceptionMessage = exceptionType.Message,
                            StackTrace = exceptionType.StackTrace.ToString()
                        }.ToString());

                        
                    }
                });
            });
        }
    }
}
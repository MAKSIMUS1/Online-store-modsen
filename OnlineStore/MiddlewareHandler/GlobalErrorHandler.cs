using System;
using System.Net;
using System.Text.Json;
using BLL.Errors;
using Microsoft.AspNetCore.Http;
using FluentValidation;

namespace OnlineStore.MiddlewareHandlers
{
    public class GlobalErrorHandler
    {
        private readonly RequestDelegate _next;

        public GlobalErrorHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                await HandleExceptionAsync(context, error);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            int statusCode;
            string errorMessage;

            switch (error)
            {
                case ValidationException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    errorMessage = "Validation error occurred";
                    break;
                case InvalidUserLoginError:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    errorMessage = "Invalid user login error";
                    break;
                case UserLoginNotFound:
                    statusCode = (int)HttpStatusCode.Unauthorized;
                    errorMessage = "User login not found";
                    break;
                case CreateIdentityUserException:
                    statusCode = (int)HttpStatusCode.Unauthorized;
                    errorMessage = "Error creating identity user";
                    break;
                case UserPasswordError:
                    statusCode = (int)HttpStatusCode.Unauthorized;
                    errorMessage = "User password error";
                    break;
                case JwtKeyNotFound:
                    statusCode = (int)HttpStatusCode.Unauthorized;
                    errorMessage = "JWT key not found";
                    break;
                default:
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    errorMessage = "An internal server error occurred";
                    break;
            }

            response.StatusCode = statusCode;

            var errorResponse = new
            {
                message = errorMessage,
                exceptionType = error.GetType().Name,
                stackTrace = error.StackTrace
            };

            var result = JsonSerializer.Serialize(errorResponse);
            await response.WriteAsync(result);
        }
    }
}
using RedCloud.Application.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Authentication;

namespace RedCloud.MIddleware
{
    public class ExceptionHandlerMIddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionHandlerMIddleware(RequestDelegate next, ILogger<ExceptionHandlerMIddleware> logger)
        {
            next = next; logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", null);
                var message = ConvertException(context, ex);
                context.Response.Redirect("/ErrorHandler/" + message);
            }
        }

        private int ConvertException(HttpContext context, Exception exception)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;

            context.Response.ContentType = "application/json";

            switch (exception)
            {
                case ValidationException valIdationException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    break;
                case BadRequestException badRequestException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    break;
                case NotFoundException notFoundException:
                    httpStatusCode = HttpStatusCode.NotFound;
                    break;
                case NotImplementedException appexception:
                    httpStatusCode = HttpStatusCode.NotImplemented;
                    break;
                case UnauthorizedAccessException unAuthException:
                    httpStatusCode = HttpStatusCode.Unauthorized;
                    break;
                case AuthenticationException authenticationException:
                    httpStatusCode = HttpStatusCode.ServiceUnavailable;
                    break;
                case Exception ex:
                    httpStatusCode = HttpStatusCode.InternalServerError;
                    break;
            }
            return (int)httpStatusCode;
        }


    }
}

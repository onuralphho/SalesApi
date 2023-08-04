using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using SalesProject.Exceptions;
using System.Net;

namespace SalesProject.Filters
{
    public class ErrorHandlingFilter : ExceptionFilterAttribute
    {

        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var problemDetails = new ProblemDetails();
            if (exception is BadRequestException badRequestException)
            {
                problemDetails.Detail = badRequestException.ErrorCode;
                problemDetails.Status = (int)HttpStatusCode.BadRequest;
                problemDetails.Title = badRequestException.Message;

            }
            else
            {
                problemDetails.Title = exception.Message;
                problemDetails.Detail = exception.ToString();
                problemDetails.Status = (int)HttpStatusCode.InternalServerError;
            }

            context.Result = new ObjectResult(problemDetails);

            context.ExceptionHandled = true;

            base.OnException(context);

        }
    }
}

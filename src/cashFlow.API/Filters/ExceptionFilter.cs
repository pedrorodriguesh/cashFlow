using cashFlow.Communication.Responses;
using cashFlow.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace cashFlow.API.Filters;

// This filter will catch every exception thrown in the application and return a response with the error
public class ExceptionFilter : IExceptionFilter
{
    // main method
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is CashFlowException)
        {
            HandleProjectException(context);
        }
        else
        {
            ThrowUnknownError(context);
        }
    }

    private static void HandleProjectException(ExceptionContext context)
    {
        if (context.Exception is ErrorOnValidationException exception)
        {
            var errorResponse = new ResponseErrorJson(exception.Errors);
            
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(errorResponse);
        }
        else
        {
            var errorResponse = new ResponseErrorJson(context.Exception.Message);
            
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(errorResponse);
        }
    }
    
    // generic error
    private static void ThrowUnknownError(ExceptionContext context)
    {
        var errorResponse = new ResponseErrorJson("unknown error");

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}
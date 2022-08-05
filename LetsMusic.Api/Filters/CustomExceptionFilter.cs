using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using LetsMusic.CrossCutting.Exceptions;
using System.Net;

namespace LetsMusic.Api.Filters
{
    public class CustomExceptionFilterAtribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            if (context.Exception is IdNotFoundException)
            {
                var result = new ObjectResult(context.Exception.Message)
                {
                    StatusCode = (int)HttpStatusCode.NotFound
                };
                context.Result = result;
            }
            if (context.Exception is ValidationException)
            {
                var result = new ObjectResult(context.Exception.Message)
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
                context.Result = result;
            }
            if (context.Exception is NotImplementedException)
            {
                var result = new ObjectResult("Funcionalidade ainda não implementada :(")
                {
                    StatusCode = (int)HttpStatusCode.NotImplemented
                };
                context.Result = result;
            }
        }
    }
}

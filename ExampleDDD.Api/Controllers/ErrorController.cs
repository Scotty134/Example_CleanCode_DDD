﻿using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ExampleDDD.Api.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            //var (statusCode, message) = exception switch
            //{
            //    IError serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
            //    _ => (StatusCodes.Status500InternalServerError, "An unexpected error occured.")
            //};

            //return Problem(statusCode: statusCode, title: message);
            return Problem();
        }
    }
}

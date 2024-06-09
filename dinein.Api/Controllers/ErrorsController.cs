using dinein.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace dinein.Api.Controllers
{
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            var (statusCode, message) = exception switch
            {
                DuplicateEmailException => (StatusCodes.Status409Conflict, "Email already exists"),
                _ => (StatusCodes.Status500InternalServerError, "An error occurred")
            };
            return Problem(statusCode: statusCode, title: message);
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, the resource you requested could not be found";
                    logger.LogError($"this request is not found {statusCode}");
                    break;
            }

            return View("NotFound");
        }
        [Route("/Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            if (exceptionDetails != null)
            {
                logger.LogError($"Error handler path is  {exceptionDetails.Path}.");
            }
            else
            {
                ViewBag.ExceptionPath = "Not Found";
                ViewBag.ExceptionMessage = "Not Found";
                ViewBag.StackTrace = "Not Found";
            }
            return View("Error");
        }
    }
}

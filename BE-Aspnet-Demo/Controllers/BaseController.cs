using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using be_aspnet_demo.controllers.response;
using be_aspnet_demo.models.exceptions;

namespace be_aspnet_demo.controllers;

[Route("/api/[controller]")]
[Produces("application/json")]
[ApiController]
public class BaseController : ControllerBase
{
    /// <summary>
    /// Create a proper response for client, based on the response object
    /// </summary>
    protected ObjectResult Handle([ActionResultObjectValue] object response)
    {
        var responseError = new ApiResponse(false);

        switch (response)
        {
            case BaseException e:
                // var responseError = new ApiResponse(false)
                responseError.ErrorCode = e.ErrorCode;
                responseError.ErrorMessage = e.Message;

                return new ObjectResult(responseError)
                {
                    StatusCode = e.HTTPStatusCode,
                };
            case Exception ex:

                Console.WriteLine("\nMessage ---\n{0}", ex.Message);
                Console.WriteLine(
                    "\nHelpLink ---\n{0}", ex.HelpLink);
                Console.WriteLine("\nSource ---\n{0}", ex.Source);
                Console.WriteLine(
                    "\nStackTrace ---\n{0}", ex.StackTrace);
                Console.WriteLine(
                    "\nTargetSite ---\n{0}", ex.TargetSite);

                responseError.ErrorCode = "INTERNAL_ERROR";
                responseError.ErrorMessage = "Internal Server Error";
                return new ObjectResult(responseError)
                {
                    StatusCode = 500
                };
            default:
                return new OkObjectResult(response);
        }
    }

    public override OkObjectResult Ok([ActionResultObjectValue] object? value)
    {
        if (value != null) return base.Ok(new ApiResponse(value));
        return base.Ok(new ApiResponse(true));
    }
}
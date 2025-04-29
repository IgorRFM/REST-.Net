using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace Galeria.Controllers;

[ApiController]
[Route("[controller]")]

public class ApiController : ControllerBase{
    protected IActionResult Problem(List<Error> errors){
        var FirstError = errors[0];
        var statusCode = FirstError.Type switch
        {
            ErrorType.Validation => StatusCodes.Status422UnprocessableEntity,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Unexpected => StatusCodes.Status500InternalServerError,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(
            statusCode: statusCode,
            title: FirstError.Description
        );
    }

}
namespace Galeria.Controllers;
using Microsoft.AspNetCore.Mvc;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem("Ocorreu um erro inesperado.");
    }
}

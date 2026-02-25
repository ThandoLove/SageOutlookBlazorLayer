using Microsoft.AspNetCore.Mvc;

namespace SageX3OutlookAPI.Controllers;



[ApiController]
[Route("api/[controller]")]
public abstract class ApiController : ControllerBase
{
    protected IActionResult Success<T>(T data)
        => Ok(new { success = true, data });

    protected IActionResult Failure(string error)
        => BadRequest(new { success = false, error });
}
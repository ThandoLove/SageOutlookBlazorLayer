using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SageX3OutlookApplication.Interfaces;

namespace SageX3OutlookAPI.Controllers;

[Authorize(Policy = "AdminOnly")]
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService) => _userService = userService;

    [HttpGet("all")]
    public async Task<IActionResult> GetAllUsers()
    {
        var result = await _userService.GetAllAsync();
        return Ok(result);
    }
}

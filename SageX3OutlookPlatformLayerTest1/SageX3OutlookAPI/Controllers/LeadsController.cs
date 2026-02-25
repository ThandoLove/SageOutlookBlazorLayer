using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SageX3OutlookApplication.Interfaces;
using SageX3OutlookApplication.Requests.LeadsR;


namespace SageX3OutlookAPI.Controllers;


[Authorize]
[Route("api/leads")]
public class LeadsController : ApiController
{
    private readonly ILeadService _leadService;

    public LeadsController(ILeadService leadService) => _leadService = leadService;

    [HttpPost("create")]
    public async Task<IActionResult> CreateLead([FromBody] CreateLeadRequest request)
    {
        var result = await _leadService.CreateLeadAsync(request);
        return result.Success ? Success(result.Data) : Failure(error: result.Error ?? "An unexpected error occurred");
    }
}
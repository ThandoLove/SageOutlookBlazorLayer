using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SageX3OutlookApplication.Interfaces;
using SageX3OutlookApplication.Requests.KnowledgeR;

namespace SageX3OutlookAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class KnowledgeController : ControllerBase
{
    private readonly IKnowledgeService _knowledgeService;

    public KnowledgeController(IKnowledgeService knowledgeService)
        => _knowledgeService = knowledgeService;

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateKnowledgeRequest request)
    {
        var result = await _knowledgeService.CreateAsync(request);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _knowledgeService.GetAllAsync();
        return Ok(result);
    }
}

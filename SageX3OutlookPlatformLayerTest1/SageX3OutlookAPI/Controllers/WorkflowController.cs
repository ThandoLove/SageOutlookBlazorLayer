
using Microsoft.AspNetCore.Mvc;
using SageX3OutlookApplication.Interfaces;
using SageX3OutlookApplication.Requests.WorkflowR;

namespace SageX3OutlookAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkflowController : ControllerBase
{
    private readonly IWorkFlowService _workflowService;

    public WorkflowController(IWorkFlowService workflowService)
    {
        _workflowService = workflowService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateWorkflowRequest request)
    {
        var result = await _workflowService.CreateAsync(request);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _workflowService.GetAllAsync());
    }
}

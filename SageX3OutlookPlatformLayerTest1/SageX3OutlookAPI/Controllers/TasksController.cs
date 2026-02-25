using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SageX3OutlookApplication.Interfaces;
using SageX3OutlookApplication.Requests.TasksR;

namespace SageX3OutlookAPI.Controllers;


[Authorize]
[Route("api/tasks")]
public class TasksController : ApiController
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService) => _taskService = taskService;

    [HttpPost("create")]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskRequest request)
    {
        var result = await _taskService.CreateTaskAsync(request);
        return !result.Success ? Failure(error: result.Error ?? "An error occurred creating the task") : Success(result.Data);
    }
}
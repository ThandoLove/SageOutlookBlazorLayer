using System;
using System.Collections.Generic;
using System.Text;

namespace SageX3OutlookApplication.Requests.TasksR;

public class CreateTaskRequest
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public DateTime DueDate { get; set; }
    public Guid AssignedToUserId { get; set; }
    public string? Subject { get; set; }
    public string? AssignedTo { get;  set; }
}
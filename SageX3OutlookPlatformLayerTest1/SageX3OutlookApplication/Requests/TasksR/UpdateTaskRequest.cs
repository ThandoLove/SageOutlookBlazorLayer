using System;
using System.Collections.Generic;
using System.Text;

namespace SageX3OutlookApplication.Requests.TasksR;

public class UpdateTaskRequest
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
    public Guid? AssignedToUserId { get; set; }
    public string? Subject { get; internal set; }
}
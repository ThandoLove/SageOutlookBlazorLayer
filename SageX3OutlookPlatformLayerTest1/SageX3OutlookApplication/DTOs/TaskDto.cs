using System;
using System.Collections.Generic;
using System.Text;

namespace SageX3OutlookApplication.DTOs

{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; } = DateTime.UtcNow.AddDays(1);
        public string AssignedTo { get; set; } = string.Empty;
        public object? Title { get; set; }
       
        public SageX3OutlookDomain.Enums.TaskStatus Status { get; set; }
    }
}

namespace SageX3OutlookDomain.Entities;

public class TaskItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Subject { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DueDate { get; set; } = DateTime.UtcNow.AddDays(1);
    public string AssignedTo { get; set; } = string.Empty;
    public bool Completed { get; set; } = false;
}

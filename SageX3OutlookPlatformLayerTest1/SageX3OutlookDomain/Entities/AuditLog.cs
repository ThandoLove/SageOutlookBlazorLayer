namespace SageX3OutlookDomain.Entities;

public class AuditLog
{
    // ... (Keep your properties here) ...
    public string Description { get; set; } = string.Empty;
    public Guid Id { get; private set; }

    public Guid EntityId { get; private set; } 
    public string EntityName { get; private set; } = string.Empty; 
    public string Action { get; private set; } = string.Empty;    
    public string PerformedBy { get; private set; } = string.Empty; 
    public DateTime OccurredOnUtc { get; private set; }
    public string? Changes { get; private set; }
    public string? TenantId { get; private set; }

    private AuditLog() { }

    // REPLACE YOUR OLD 'Create' METHOD WITH THIS ONE:
    public static AuditLog Create(
        string entityName,
        Guid entityId,
        string action,
        string performedBy,
        string description, // Added parameter
        string? changes = null,
        string? tenantId = null)
    {
        return new AuditLog
        {
            Id = Guid.NewGuid(),
            EntityName = entityName,
            EntityId = entityId,
            Action = action,
            PerformedBy = performedBy,
            Description = description, // Added assignment
            Changes = changes,
            TenantId = tenantId,
            OccurredOnUtc = DateTime.UtcNow
        };
    }

}

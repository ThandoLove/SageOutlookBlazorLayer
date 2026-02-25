namespace SageX3OutlookDomain.Entities;

public class AutoLinkResult
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string EmailId { get; set; } = string.Empty;
    public string ErpId { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Add any other database-specific fields here
}

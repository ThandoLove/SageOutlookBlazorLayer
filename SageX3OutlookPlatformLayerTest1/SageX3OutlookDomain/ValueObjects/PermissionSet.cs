

namespace SageX3OutlookDomain.ValueObjects;
public class PermissionSet
{
    public bool CanCreateLead { get; set; } = true;
    public bool CanEditLead { get; set; } = true;
    public bool CanDeleteLead { get; set; } = false;

    public bool CanCreateTask { get; set; } = true;
    public bool CanEditTask { get; set; } = true;
    public bool CanDeleteTask { get; set; } = false;

    public bool CanViewKnowledge { get; set; } = true;
    public bool CanEditKnowledge { get; set; } = false;
}
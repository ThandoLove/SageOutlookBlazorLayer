
namespace SageX3OutlookDomain.Entities;
public class Opportunity
{


    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Account { get; set; } = string.Empty;
    public decimal Value { get; set; }
    public string Stage { get; set; } = string.Empty;
    public Guid OwnerId { get; set; }
    public decimal Amount { get; set; } = 0;
}
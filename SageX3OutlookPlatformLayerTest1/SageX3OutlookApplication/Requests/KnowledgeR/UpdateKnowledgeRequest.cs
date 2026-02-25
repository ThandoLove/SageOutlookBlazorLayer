
namespace SageX3OutlookApplication.Requests.KnowledgeR;

public class UpdateKnowledgeRequest
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
}
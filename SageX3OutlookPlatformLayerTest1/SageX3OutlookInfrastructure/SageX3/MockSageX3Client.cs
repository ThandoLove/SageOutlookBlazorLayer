using SageX3OutlookApplication.Interfaces;
using SageX3OutlookDomain.Entities;

namespace SageX3OutlookInfrastructure.SageX3;

public class MockSageX3Client : ISageX3Client
{
    public Task<bool> PushLeadAsync(Lead lead)
    {
        Console.WriteLine($"[MOCK] Pushing Lead to Sage: {lead.CompanyName}");
        return Task.FromResult(true);
    }

    public Task<bool> PushTaskAsync(TaskItem task)
    {
        Console.WriteLine($"[MOCK] Pushing Task to Sage: {task.Subject}");
        return Task.FromResult(true);
    }
}

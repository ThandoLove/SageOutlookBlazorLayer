using SageX3OutlookApplication.Interfaces;
using SageX3OutlookDomain.Entities;
using SageX3OutlookInfrastructure.ERP_Authentication;


namespace SageX3OutlookInfrastructure.SageX3;

public class SageX3Client : ISageX3Client
{
    private readonly ISageAuthService _auth;

    public SageX3Client(ISageAuthService auth) => _auth = auth;

    public async Task<bool> PushLeadAsync(Lead lead)
    {
        var token = await _auth.GetTokenAsync();
        Console.WriteLine($"[Mock ERP] Pushing Lead: {lead.CompanyName}, Token: {token.AccessToken}");
        await Task.Delay(50); // simulate network
        return true;
    }

    public async Task<bool> PushTaskAsync(TaskItem task)
    {
        var token = await _auth.GetTokenAsync();
        Console.WriteLine($"[Mock ERP] Pushing Task: {task.Subject}, Token: {token.AccessToken}");
        await Task.Delay(50); // simulate network
        return true;
    }
}
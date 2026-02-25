using SageX3OutlookApplication.DTOs;
using SageX3OutlookApplication.Interfaces;
using SageX3OutlookDomain.Entities;



namespace SageX3OutlookApplication.Services;



public class SageX3Service : ISageX3Service
{
    private readonly ISageX3Client _client;

    public SageX3Service(ISageX3Client client) => _client = client;

    public Task<bool> PushLeadAsync(Lead lead) => _client.PushLeadAsync(lead);
    public Task<bool> PushTaskAsync(TaskItem task) => _client.PushTaskAsync(task);

    public Task<bool> SyncContactAsync(ContactDto contact)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SyncLeadAsync(LeadDto lead)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SyncTaskAsync(TaskDto task)
    {
        throw new NotImplementedException();
    }
}
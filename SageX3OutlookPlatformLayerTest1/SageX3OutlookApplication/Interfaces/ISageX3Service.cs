using SageX3OutlookApplication.DTOs;


namespace SageX3OutlookApplication.Interfaces;

public interface ISageX3Service
{
    Task<bool> SyncContactAsync(ContactDto contact);
    Task<bool> SyncTaskAsync(TaskDto task);
    Task<bool> SyncLeadAsync(LeadDto lead);
}

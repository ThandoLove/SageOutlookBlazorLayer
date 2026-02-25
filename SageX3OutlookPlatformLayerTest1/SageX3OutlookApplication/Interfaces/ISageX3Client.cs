
using SageX3OutlookDomain.Entities;

namespace SageX3OutlookApplication.Interfaces;


public interface ISageX3Client
{
    Task<bool> PushLeadAsync(Lead lead);
    Task<bool> PushTaskAsync(TaskItem task);
}
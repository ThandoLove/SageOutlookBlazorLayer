using SageX3OutlookDomain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SageX3OutlookApplication.Interfaces;

public interface IAttachmentRepository
{
    Task AddAsync(Attachment entity);
    Task<Attachment?> GetByIdAsync(Guid id);
    Task<List<Attachment>> GetAllAsync();
    Task UpdateAsync(Attachment entity);
}

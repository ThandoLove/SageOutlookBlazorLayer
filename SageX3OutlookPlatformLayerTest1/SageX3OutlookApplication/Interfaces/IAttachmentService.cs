using SageX3OutlookApplication.Requests.AttachmentR;

using SageX3OutlookApplication.DTOs;

namespace SageX3OutlookApplication.Interfaces;

public interface IAttachmentService
{
    Task<AttachmentDto> UploadAttachmentAsync(UploadAttachmentRequest request);
    Task<AttachmentDto> CreateAsync(CreateAttachmentRequest request);
    Task<AttachmentDto> UpdateAsync(UpdateAttachmentRequest request);
    Task<List<AttachmentDto>> GetAllAsync();
}

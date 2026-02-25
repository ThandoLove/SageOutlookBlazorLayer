using SageX3OutlookApplication.DTOs;
using SageX3OutlookApplication.Interfaces;
using SageX3OutlookApplication.Requests.AttachmentR;
using SageX3OutlookDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SageX3OutlookApplication.Services;

public class AttachmentService : IAttachmentService
{
    private readonly IAttachmentRepository _repository;

    public AttachmentService(IAttachmentRepository repository)
    {
        _repository = repository;
    }

    // FIXED: Added missing method required by IAttachmentService and Controller
    public async Task<AttachmentDto> UploadAttachmentAsync(UploadAttachmentRequest request)
    {
        var entity = new Attachment
        {
            Id = Guid.NewGuid(),
            FileName = request.FileName,
            ContentType = request.ContentType
            // Note: Map request.FileStream to byte[] if your entity supports it
        };

        await _repository.AddAsync(entity);

        return new AttachmentDto
        {
            Id = entity.Id,
            FileName = entity.FileName,
            Success = true
        };
    }

    public async Task<AttachmentDto> CreateAsync(CreateAttachmentRequest request)
    {
        var entity = new Attachment { Id = Guid.NewGuid(), FileName = "New Attachment" };
        await _repository.AddAsync(entity);
        return new AttachmentDto { Id = entity.Id, Success = true };
    }

    public async Task<AttachmentDto> UpdateAsync(UpdateAttachmentRequest request)
    {
        var entity = await _repository.GetByIdAsync(request.Id)
            ?? throw new InvalidOperationException("Attachment not found");

        // Update logic here...

        await _repository.UpdateAsync(entity);
        return new AttachmentDto { Id = entity.Id, Success = true };
    }

    public async Task<List<AttachmentDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return entities.Select(e => new AttachmentDto
        {
            Id = e.Id,
            FileName = e.FileName
        }).ToList();
    }
}

using System;

namespace SageX3OutlookApplication.DTOs



{
    public class AttachmentDto
    {
        public Guid Id { get; set; }

        public string FileName { get; set; } = string.Empty;

        public string ContentType { get; set; } = string.Empty;

        public long FileSize { get; set; }

        public string? Description { get; set; }

        public Guid? RelatedEntityId { get; set; }

        public string? RelatedEntityType { get; set; }
        // Example: "Contact", "Lead", "Opportunity"

        public DateTime UploadedAtUtc { get; set; }

        public Guid UploadedByUserId { get; set; }

        public string? ExternalSageId { get; set; }
        public bool Success { get; set; }
        public object? Data { get; set; }
        public object? Error { get; set; }
        // ID returned by Sage X3 after sync
    }
}
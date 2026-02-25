using System;
using System.Collections.Generic;
using System.Text;

namespace SageX3OutlookApplication.Responses

{
    public class AttachmentResponse
    {
        public Guid Id { get; set; }

        public string? FileName { get; set; }

        public string? ContentType { get; set; }

        public long FileSize { get; set; }

        public string? UploadedBy { get; set; }

        public DateTime UploadedAtUtc { get; set; }

        // Optional: Related entity reference
        public Guid? OpportunityId { get; set; }
        public Guid? TaskId { get; set; }
        public Guid? KnowledgeId { get; set; }

        // Optional: Download endpoint URL
        public string? DownloadUrl { get; set; }
    }
}
using System;
using System.IO;

namespace SageX3OutlookApplication.Requests.AttachmentR

{
    public class UploadAttachmentRequest
    {
        public string FileName { get; set; } = string.Empty;

        public string ContentType { get; set; } = string.Empty;

        public Stream FileStream { get; set; } = Stream.Null;

        public Guid RelatedEntityId { get; set; }

        public string RelatedEntityType { get; set; } = string.Empty;

        public string? Description { get; set; }
        // Add this missing property
        public byte[] Data { get; set; } = Array.Empty<byte>();

        
       
    }
}


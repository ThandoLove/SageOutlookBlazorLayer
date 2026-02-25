using System;
using System.Collections.Generic;
using System.Text;

namespace SageX3OutlookApplication.Requests.AttachmentR;

public class UpdateAttachmentRequest
{
    public Guid Id { get; set; }
    public string? FileName { get; set; }
    public string? FileType { get; set; }
    public byte[]? Content { get; set; }
}
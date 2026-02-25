using System;
using System.Collections.Generic;
using System.Text;

namespace SageX3OutlookApplication.Requests.AttachmentR;

public class CreateAttachmentRequest
{
    public string FileName { get; set; } = null!;
    public string FileType { get; set; } = null!;
    public byte[] Content { get; set; } = null!;
}
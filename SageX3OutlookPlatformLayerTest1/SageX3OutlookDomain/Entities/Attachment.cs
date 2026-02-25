using System;
using System.Collections.Generic;
using System.Text;

namespace SageX3OutlookDomain.Entities;
public class Attachment
{
    public Guid Id { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
    public byte[] Data { get; set; } = Array.Empty<byte>();
}
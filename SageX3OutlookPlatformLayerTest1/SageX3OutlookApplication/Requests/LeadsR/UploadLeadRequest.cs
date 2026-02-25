using System;
using System.Collections.Generic;
using System.Text;

namespace SageX3OutlookApplication.Requests.LeadsR;


public class UploadLeadRequest
{
    public string FileName { get; set; } = null!;
    public byte[] Content { get; set; } = null!;
}
using System;


namespace SageX3OutlookApplication.Requests.ContactsR;


public class UploadContactRequest
{
    public string FileName { get; set; } = null!;
    public byte[] Content { get; set; } = null!;
}
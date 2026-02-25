using SageX3OutlookApplication.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SageX3OutlookApplication.BusinessRules;

public static class AutoLinkRule
{
    public static bool ShouldAutoLink(string entityType) => entityType switch
    {
        "Lead" => true,
        "Task" => false,
        _ => false
    };
    public static void Apply(ContactDto contact, EmailDto email)
    {
        // Example: match email with contact
        if (contact.Email == email.From)
        {
            email.LinkedContactId = contact.Id;
        }
    }
}
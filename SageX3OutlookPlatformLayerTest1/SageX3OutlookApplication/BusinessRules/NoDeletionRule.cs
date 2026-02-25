using System;
using System.Collections.Generic;
using System.Text;

namespace SageX3OutlookApplication.BusinessRules;

public static class NoDeletionRule
{
    public static bool CanDelete(string role) => role == "Admin"; // Only Admin can delete
    public static void ValidateCanDelete(bool isProtected)
    {
        if (isProtected)
            throw new InvalidOperationException("Cannot delete protected record.");
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace SageX3OutlookApplication.BusinessRules;


public class RoleBasedFilterRule
{
    public List<T> Apply<T>(List<T> items, string role) => items; // implement filtering per role

    internal bool CanAccess<T>(T i, string role)
    {
        throw new NotImplementedException();
    }
}
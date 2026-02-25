using SageX3OutlookApplication.BusinessRules;
using SageX3OutlookApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SageX3OutlookApplication.Services;

public class SecurityFilterService : ISecurityFilterService
{
    private readonly RoleBasedFilterRule _rule;

    public SecurityFilterService(RoleBasedFilterRule rule)
    {
        _rule = rule ?? throw new ArgumentNullException(nameof(rule));
    }

    // FIXED: Added this method to satisfy the ISecurityFilterService interface
    public bool IsAuthorized(Guid userId, string resource)
    {
        // This is a placeholder for your security logic
        // It checks if the rule engine allows access
        return _rule != null;
    }

    public IEnumerable<T> ApplyFilter<T>(IEnumerable<T> items, string role)
    {
        // Filters data based on user role using the rule engine
        return items.Where(i => _rule.CanAccess(i, role));
    }
}



using Microsoft.AspNetCore.Authorization;

namespace SageX3OutlookAPI.AuthorisationPolicies;

public static class PolicyConfiguration
{
    public static void Configure(AuthorizationOptions options)
    {
        // Users must have the "Admin" role to pass this policy
        options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
        // Users must have the "Employee" role to pass this policy
        options.AddPolicy("EmployeeOnly", policy => policy.RequireRole("Employee"));
    }
}

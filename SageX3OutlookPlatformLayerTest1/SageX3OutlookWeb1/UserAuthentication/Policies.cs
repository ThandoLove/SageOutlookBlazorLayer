
using Microsoft.AspNetCore.Authorization;

public static class Policies
{
    public const string AdminOnly = "AdminOnly";

    public static void AddPolicies(AuthorizationOptions options)
    {
        options.AddPolicy(AdminOnly, policy => policy.RequireRole("Admin"));
    }
}
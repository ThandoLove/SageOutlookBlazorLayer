
namespace SageX3OutlookInfrastructure.Configuration;
public class SageSecurityOptions
{
    public string TokenEndpoint { get; set; } = "https://mock-sagex3.local/auth/token";
    public int TokenExpiryMinutes { get; set; } = 60;
}
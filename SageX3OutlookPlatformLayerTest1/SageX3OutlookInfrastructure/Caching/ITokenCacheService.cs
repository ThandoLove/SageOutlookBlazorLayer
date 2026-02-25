using SageX3OutlookInfrastructure.ERP_Authentication;


namespace SageX3OutlookInfrastructure.Caching;
public interface ITokenCacheService
{
    Task<TokenResponse?> GetTokenAsync();
    Task StoreTokenAsync(TokenResponse token);
}
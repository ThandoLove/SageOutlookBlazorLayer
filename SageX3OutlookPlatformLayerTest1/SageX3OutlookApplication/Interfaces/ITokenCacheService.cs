using SageX3OutlookApplication.Interfaces;
using SageX3OutlookApplication.Responses;


namespace SageX3OutlookApplication.Interfaces;
public interface ITokenCacheService
{
    Task<TokenResponse?> GetTokenAsync();
    Task StoreTokenAsync(TokenResponse token);
    
}
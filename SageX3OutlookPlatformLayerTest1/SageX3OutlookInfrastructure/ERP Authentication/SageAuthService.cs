using SageX3OutlookApplication.Interfaces;
using SageX3OutlookApplication.Responses;



namespace SageX3OutlookInfrastructure.ERP_Authentication;

public class SageAuthService : ISageAuthService
{
    private readonly ITokenCacheService _cache;

    public SageAuthService(ITokenCacheService cache)
    {
        _cache = cache;
    }

    public async Task<TokenResponse> GetTokenAsync()
    {
        var cached = await _cache.GetTokenAsync();

        if (cached != null && cached.ExpiresAt > DateTime.UtcNow)
            return cached;

        //Simulate token retrieval

        var token = new TokenResponse
        {
            AccessToken = Guid.NewGuid().ToString(),
            ExpiresAt = DateTime.UtcNow.AddMinutes(60)
        };

        await _cache.StoreTokenAsync(token);

        return token;
    }

    Task<TokenResponse> ISageAuthService.GetTokenAsync()
    {
        throw new NotImplementedException();
    }
  
}
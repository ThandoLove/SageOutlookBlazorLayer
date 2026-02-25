using SageX3OutlookInfrastructure.ERP_Authentication;

namespace SageX3OutlookInfrastructure.Caching;

public class DistributedTokenCacheService : ITokenCacheService
{
    private TokenResponse? _token;

    public Task<TokenResponse?> GetTokenAsync() => Task.FromResult(_token);

    public Task StoreTokenAsync(TokenResponse token)
    {
        _token = token;
        return Task.CompletedTask;
    }
}
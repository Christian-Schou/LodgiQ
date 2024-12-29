namespace Lodgingly.Framework.Application.Caching;

public interface ICacheService
{
    Task<TObject?> GetAsync<TObject>(string key, CancellationToken cancellationToken = default);

    Task SetAsync<TObject>(string key, TObject value, TimeSpan? expiration = null,
        CancellationToken cancellationToken = default);

    Task RemoveAsync(string key, CancellationToken cancellationToken = default);
}
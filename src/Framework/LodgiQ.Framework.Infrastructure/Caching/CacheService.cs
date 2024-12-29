using System.Buffers;
using System.Text.Json;
using LodgiQ.Framework.Application.Caching;
using Microsoft.Extensions.Caching.Distributed;

namespace LodgiQ.Framework.Infrastructure.Caching;

internal sealed class CacheService(IDistributedCache cache) : ICacheService
{
    public async Task<TObject?> GetAsync<TObject>(string key, CancellationToken cancellationToken = default)
    {
        byte[]? bytes = await cache.GetAsync(key, cancellationToken);

        return bytes is null ? default : Deserialize<TObject>(bytes);
    }

    public Task SetAsync<TObject>(string key, TObject value, TimeSpan? expiration = null,
        CancellationToken cancellationToken = default)
    {
        byte[] bytes = Serialize(value);
        return cache.SetAsync(key, bytes, CacheOptions.Create(expiration), cancellationToken);
    }

    public Task RemoveAsync(string key, CancellationToken cancellationToken = default)
    {
        return cache.RemoveAsync(key, cancellationToken);
    }

    private static TObject Deserialize<TObject>(byte[] bytes)
    {
        return JsonSerializer.Deserialize<TObject>(bytes)!;
    }

    private static byte[] Serialize<TObject>(TObject value)
    {
        var buffer = new ArrayBufferWriter<byte>();
        using var writer = new Utf8JsonWriter(buffer);
        JsonSerializer.Serialize(writer, value);
        return buffer.WrittenSpan.ToArray();
    }
}
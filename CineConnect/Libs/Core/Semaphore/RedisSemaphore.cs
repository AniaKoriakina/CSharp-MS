using StackExchange.Redis;

namespace Core.Semaphore;

public class RedisSemaphore : IDistributedSemaphore
{
    private readonly ConnectionMultiplexer _redis;
    private readonly IDatabase _db;

    public RedisSemaphore(string connectionString)
    {
        _redis = ConnectionMultiplexer.Connect(connectionString);
        _db = _redis.GetDatabase();
    }

    public async Task<bool> WaitAsync(string key, TimeSpan timeout)
    {
        var token = Guid.NewGuid().ToString();
        var acquired = await _db.StringSetAsync(key, token, TimeSpan.FromSeconds(timeout.TotalSeconds), When.NotExists);
        return acquired;
    }

    public async Task ReleaseAsync(string key)
    {
        await _db.KeyDeleteAsync(key);
    }
}
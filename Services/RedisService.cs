using StackExchange.Redis;
using Newtonsoft.Json;
using System.Threading.Tasks;

public class RedisService
{
    private readonly IConnectionMultiplexer _redis;

    public RedisService(IConnectionMultiplexer redis)
    {
        _redis = redis;
    }

    public async Task SetCacheAsync(string key, object value)
    {
        var db = _redis.GetDatabase();
        await db.StringSetAsync(key, JsonConvert.SerializeObject(value));
    }

    public async Task<T> GetCacheAsync<T>(string key)
    {
        var db = _redis.GetDatabase();
        var value = await db.StringGetAsync(key);
        return value.IsNullOrEmpty ? default : JsonConvert.DeserializeObject<T>(value);
    }
}

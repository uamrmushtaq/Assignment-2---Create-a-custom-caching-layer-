using System.Threading.Tasks;

namespace CentralizedCachingAPI.Services
{
    public interface ICacheService
    {
        Task<string> GetCachedResponseAsync(string requestParameters);
        Task CacheResponseAsync(string requestParameters, string responseData);
        Task CleanupExpiredCacheAsync();
    }
}

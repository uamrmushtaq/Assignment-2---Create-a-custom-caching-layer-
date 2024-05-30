using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CentralizedCachingAPI.Data;
using CentralizedCachingAPI.Models;

namespace CentralizedCachingAPI.Services
{
    public class CacheService : ICacheService
    {
        private readonly ApplicationDbContext _context;

        public CacheService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> GetCachedResponseAsync(string requestParameters)
        {
            var cachedResponse = await _context.CachedResponses
                .Where(cr => cr.RequestParameters == requestParameters && cr.ExpirationTime > DateTime.Now)
                .FirstOrDefaultAsync();

            return cachedResponse?.ResponseData;
        }

        public async Task CacheResponseAsync(string requestParameters, string responseData)
        {
            var expirationTime = DateTime.Now.AddHours(2);
            var cachedResponse = new CachedResponse
            {
                RequestParameters = requestParameters,
                ResponseData = responseData,
                ExpirationTime = expirationTime
            };

            _context.CachedResponses.Add(cachedResponse);
            await _context.SaveChangesAsync();
        }

        public async Task CleanupExpiredCacheAsync()
        {
            var expiredResponses = _context.CachedResponses
                .Where(cr => cr.ExpirationTime <= DateTime.Now);

            _context.CachedResponses.RemoveRange(expiredResponses);
            await _context.SaveChangesAsync();
        }
    }
}

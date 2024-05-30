using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CentralizedCachingAPI.Services
{
    public class CacheCleanupService : BackgroundService
    {
        private readonly ICacheService _cacheService;
        private readonly ILogger<CacheCleanupService> _logger;
        private readonly TimeSpan _cleanupInterval = TimeSpan.FromHours(1);

        public CacheCleanupService(ICacheService cacheService, ILogger<CacheCleanupService> logger)
        {
            _cacheService = cacheService;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Running cache cleanup task.");
                await _cacheService.CleanupExpiredCacheAsync();
                await Task.Delay(_cleanupInterval, stoppingToken);
            }
        }
    }
}

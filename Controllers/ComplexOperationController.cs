using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CentralizedCachingAPI.Services;

namespace CentralizedCachingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComplexOperationController : ControllerBase
    {
        private readonly ICacheService _cacheService;

        public ComplexOperationController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        [HttpGet("execute")]
        public async Task<IActionResult> Execute([FromQuery] string parameters)
        {
            // Check cache first
            var cachedResponse = await _cacheService.GetCachedResponseAsync(parameters);
            if (cachedResponse != null)
            {
                return Ok(cachedResponse);
            }

            // Simulate complex operation
            var responseData = $"Result of complex operation with parameters: {parameters}";

            // Cache the response
            await _cacheService.CacheResponseAsync(parameters, responseData);

            return Ok(responseData);
        }
    }
}

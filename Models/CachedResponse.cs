using System;

namespace CentralizedCachingAPI.Models
{
    public class CachedResponse
    {
        public int Id { get; set; }
        public string RequestParameters { get; set; }
        public string ResponseData { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}

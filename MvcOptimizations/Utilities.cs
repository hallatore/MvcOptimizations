using System;
using System.Web;
using System.Web.Caching;

namespace MvcOptimizations
{
    public class Utilities
    {
        public static T Cache<T>(string key, TimeSpan duration, Func<T> action, CacheItemPriority priority = CacheItemPriority.Normal) where T : class
        {
            var result = HttpRuntime.Cache[key] as T;

            if (result == null)
            {
                result = action();
                HttpRuntime.Cache.Add(key,
                    result,
                    null,
                    DateTime.Now + duration,
                    System.Web.Caching.Cache.NoSlidingExpiration,
                    priority,
                    null);
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Helper
{
    public class CacheManage
    {
        private static System.Web.Caching.Cache cache = HttpRuntime.Cache;
        private static object _lock = new object();

        public static void SaveCache(string key, object obj, string fileName)
        {
            if (string.IsNullOrEmpty(key) || obj == null)
                return;
            lock (_lock)
            {
                cache.Insert(key, obj, new System.Web.Caching.CacheDependency(fileName));
            }
        }
        public static object GetCache(string key)
        {
            if (string.IsNullOrEmpty(key))
                return null;
            return cache[key];
        }
    }
}

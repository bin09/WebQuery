using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Helper;

namespace SolrLib
{
    public class ConfigSetting
    {
        private static string fileName = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "FileConfig/SolrConfig.xml");
        private static object _lock = new object();
        private static string solrConfigCache = "solrQueryCache";

        public static SolrConfig GetConfig()
        {
            SolrConfig config = CacheManage.GetCache(solrConfigCache) as SolrConfig;
            if (config == null)
                config = SetCache();
            return config;
        }
        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <returns></returns>
        private static SolrConfig SetCache()
        {
            SolrConfig config = (SolrConfig)SerializationHelper.Load(typeof(SolrConfig), fileName);
            CacheManage.SaveCache(solrConfigCache, config, fileName);
            return config;
        }
    }
}

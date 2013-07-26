using SolrNet;
using Microsoft.Practices.ServiceLocation;
using SolrNet.Impl;
using Helper;

namespace SolrLib
{
    public class SolrHelper<T>
    {
        private static SolrConfig config = ConfigSetting.GetConfig();
        private static object _lock = new object();
        private static string url = string.Empty;

        private static SolrHelper<T> solr = null;
        private SolrHelper(string url)
        {
            InitSolr();
        }
        public static SolrHelper<T> Instance(ECore eCore)
        {
            url = GetMultiCoreSolrUrl(eCore);
            lock (_lock)
            {
                if (solr == null)
                    solr = new SolrHelper<T>(url);
            }
            return solr;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="core">实例</param>
        private void InitSolr()
        {
            var solrConnection = new SolrConnection(url);
            var loggingConnection = new LoggingConnection(solrConnection);
            Startup.Init<T>(loggingConnection);
        }
        /// <summary>
        /// ServiceLocator实例化
        /// </summary>
        /// <returns></returns>
        public ISolrOperations<T> GetSolrInstanceLocator()
        {
            return ServiceLocator.Current.GetInstance<ISolrOperations<T>>();
        }
        /// <summary>
        /// 获取多Core的url
        /// </summary>
        /// <param name="core"></param>
        /// <returns></returns>
        private static string GetMultiCoreSolrUrl(ECore core)
        {
            string url = string.Empty;
            switch (core)
            {
                case ECore.ProCore:
                    url = config.ProCore;
                    break;
                case ECore.BuyCore:
                    url = config.BuyCore;
                    break;
                case ECore.KeywordCore:
                    url = config.KeywordCore;
                    break;
                case ECore.MemberCore:
                    url = config.MemberCore;
                    break;
                case ECore.NewsCore:
                    url = config.NewsCore;
                    break;
                default:
                    break;
            }
            return url;
        }
    }
}

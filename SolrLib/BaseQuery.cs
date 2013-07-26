using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

namespace SolrLib
{
    public abstract class BaseQuery
    {
        protected SolrConfig solrConfig = ConfigSetting.GetConfig();
        protected string GetSolrIds<T>(List<T> list, string field)
        {
            if (list == null || list.Count == 0)
                return null;
            StringBuilder sb = new StringBuilder();

            foreach (var item in list)
            {
                Type itype = item.GetType();
                PropertyInfo pi = itype.GetProperty(field);
                sb.Append(pi.GetValue(item, null) + ",");
            }
            return sb.ToString().TrimEnd(',');
        }
        /// <summary>
        /// 数据库筛选出的数据，按照原先solr的顺序排列
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable SortSolrData<T>(DataTable dt, List<T> list, string pkField)
        {
            DataTable dtTemp = dt.Clone();
            foreach (var item in list)
            {
                Type itype = item.GetType();
                PropertyInfo pi = itype.GetProperty(pkField);
                DataRow[] drs = dt.Select(string.Format("{0}={1}", pkField, pi.GetValue(item, null)));
                if (drs != null && drs.Length > 0)
                {
                    DataRow dr = drs[0];
                    dtTemp.ImportRow(dr);
                }
            }
            return dtTemp;
        }

        #region 获取搜索文本
        /// <summary>
        /// 获取搜索web搜索文本
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        //protected virtual string GetWebQueryText(string query, int prBaidu)
        //{
        //    string queryText = string.Empty;
        //    if (!string.IsNullOrEmpty(query))
        //    {
        //        queryText += string.Format("+webTitle:{0} ^ {1} + prBaidu:{2} TO *", query, this.solrConfig.TitleBoost, prBaidu);
        //    }
        //    return queryText;
        //}
        #endregion
    }
}

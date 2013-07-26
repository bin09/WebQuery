using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using SolrNet;
using Helper;

namespace SolrLib
{
    public class ProQuery : BaseQuery
    {
        private SolrHelper<ModPro> solrCore = SolrHelper<ModPro>.Instance(ECore.ProCore);
        private static ISolrOperations<ModPro> solr = null;

        public ProQuery()
        {
            if (solr == null)
                solr = solrCore.GetSolrInstanceLocator();
        }
        public List<ModPro> Query(string query, int start, int rows, bool isFacet, ICollection<string> facetFields, ref IDictionary<string, ICollection<KeyValuePair<string, int>>> facetResults)
        {
            string q = QueryParse.KeywordNormal(query);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolrNet.Attributes;

namespace MODEL
{
    [Serializable]
    public class ModMember
    {
        private int id;
        [SolrUniqueKey("id")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string companyName;
        [SolrField("companyName")]
        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }
    }
}

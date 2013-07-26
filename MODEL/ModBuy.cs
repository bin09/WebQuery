using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolrNet.Attributes;

namespace MODEL
{
    [Serializable]
    public class ModBuy
    {
        private int id;
        [SolrUniqueKey("id")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string title;
        [SolrField("title")]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
    }
}

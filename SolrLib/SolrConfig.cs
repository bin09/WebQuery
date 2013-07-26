using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolrLib
{
    public class SolrConfig
    {
        public double SilverBoost
        {
            get;
            set;
        }
        public double GoldBoost
        {
            get;
            set;
        }
        public double VipBoost
        {
            get;
            set;
        }
        public string ProCore
        {
            get;
            set;
        }
        public string MemberCore
        {
            get;
            set;
        }
        public string KeywordCore
        {
            get;
            set;
        }
        public string BuyCore
        {
            get;
            set;
        }
        public string NewsCore
        {
            get;
            set;
        }
    }
}

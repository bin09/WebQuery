using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolrNet;
using System.IO;

namespace SolrLib
{
    public class LoggingConnection : ISolrConnection
    {
        private readonly ISolrConnection conn;

        public LoggingConnection(ISolrConnection conn)
        {
            this.conn = conn;
        }

        public string Post(string relativeUrl, string s)
        {
            Console.WriteLine("Posting {0}", s);
            return conn.Post(relativeUrl, s);
        }

        public string PostStream(string relativeUrl, string contentType, Stream content, IEnumerable<KeyValuePair<string, string>> parameters)
        {
            Console.WriteLine("Posting Binary");
            return conn.PostStream(relativeUrl, contentType, content, parameters);
        }

        public string Get(string relativeUrl, IEnumerable<KeyValuePair<string, string>> parameters)
        {
            Console.WriteLine("Getting");
            var r = conn.Get(relativeUrl, parameters);
            Console.WriteLine("Result is:\n" + r);
            return r;
        }
    }
}

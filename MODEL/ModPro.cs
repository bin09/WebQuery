using System;
using SolrNet.Attributes;

namespace MODEL
{
    [Serializable]
    public class ModPro
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
        private string classParPath;
        [SolrField("classParPath")]
        public string ClassParPath
        {
            get { return classParPath; }
            set { classParPath = value; }
        }
        private int provinceId;
        [SolrField("provinceId")]
        public int ProvinceId
        {
            get { return provinceId; }
            set { provinceId = value; }
        }
        private int cityId;
        [SolrField("cityId")]
        public int CityId
        {
            get { return cityId; }
            set { cityId = value; }
        }
        private string model;
        [SolrField("model")]
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
    }
}

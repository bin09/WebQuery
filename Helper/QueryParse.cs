
namespace Helper
{
    public static class QueryParse
    {
        /// <summary>
        /// 取出搜索语法的特殊字符
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static System.String Escape(System.String s)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                // These characters are part of the query syntax and must be escaped
                if (c == '\\' || c == '+' || c == '-' || c == '!' || c == '(' || c == ')' || c == ':' || c == '^' || c == '[' || c == ']' || c == '\"' || c == '{' || c == '}' || c == '~' || c == '*' || c == '?' || c == '|' || c == '&')
                {
                    sb.Append('\\');
                }
                sb.Append(c);
            }
            return sb.ToString();
        }
        //去除solr关键词查询中的非法字符
        public static string KeywordNormal(string keyword)
        {
            //+ - && || ! ( ) { } [ ] ^ ” ~ * ? : \
            string[] replacechars = "\\ + - && || ! ( ) { } [ ] ^ \" ~ * ? :".Split(' ');
            foreach (var o in replacechars)
            {
                keyword = keyword.Replace(o, "\\" + o);
            }
            keyword = System.Text.RegularExpressions.Regex.Replace(keyword, @"\s+AND$|^AND\s+|\s+AND\s+", " and ");
            keyword = System.Text.RegularExpressions.Regex.Replace(keyword, @"\s+OR$|^OR\s+|\s+OR\s+", " or ");
            if (keyword.Trim().Equals("AND"))
            {
                keyword = "and";
            }
            if (keyword.Trim().Equals("OR"))
            {
                keyword = "or";
            }
            return keyword.Trim();
        }
        //因为solr中以空格分词，所以转义空白符号为%0
        public static string KeywordRepalceWhitespace(string keyword)
        {
            //&amp;在属性值表中为&amp;但是在商品属性字段中为&，为了修补此bug，添加该转义
            return keyword.Replace(" ", "#").Replace("&amp;", "&");
        }
    }
}

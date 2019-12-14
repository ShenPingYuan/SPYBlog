using SPY.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPY.Core
{
    public class ArticleListJsonModel<T>
    {
        public ArticleListJsonModel()
        {
            data = new List<T>();
        }
        public int code { get; set; }
        public string msg { get; set; }
        public int count { get; set; }
        public List<T> data { get; set; }
    }
}

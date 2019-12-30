using System;
using System.Collections.Generic;
using System.Text;

namespace SPY.DB.Model
{
    public class Category
    {
        public Category()
        {
            Articles=new HashSet<Article>();
        }
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ParentCategoryName { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}

using SPY.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPY.View.Model
{
    public class AddArticleViewModel
    {
        public AddArticleViewModel()
        {
            Author = new ApplicationIdentityUser();
            CategoryViews = new List<CategoryViewModel>();
        }
        public string newsName { get; set; }
        public string description { get; set; }
        public string content { get; set; }
        public string newsImg { get; set; }
        public string classify { get; set; }
        public string newsStatus { get; set; }
        public DateTime newsTime { get; set; }
        public string newsTop { get; set; }
        public string authorName { get; set; }
        public string articleId { get; set; }
        public bool isTop { get; set; }
        public ApplicationIdentityUser Author { get; set; }
        public List<CategoryViewModel> CategoryViews { get; set; }
    }
}

using SPY.DB.Model;
using SPY.View.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPY.Core
{
    public static class Helper
    {
        public static int ID { get; set; }
        public static ArticleListJsonModel<ArticleViewModel> HttpJsonResult(IEnumerable<Article> articlesEntities)
        {
            ID = 0;
            ArticleListJsonModel<ArticleViewModel> articleListJsonModel = new ArticleListJsonModel<ArticleViewModel>();

            articleListJsonModel.code = 0;
            articleListJsonModel.count = articlesEntities.Count();
            articleListJsonModel.msg = "";
            foreach (Article item in articlesEntities)
            {
                ID++;
                ArticleViewModel articleViewModel = new ArticleViewModel();
                articleViewModel.id = ID;
                articleViewModel.articleID = item.Id;
                articleViewModel.articleTitle = item.Title;
                articleViewModel.publishTime = item.AddTime.ToString();
                articleViewModel.Author = item.Author;
                articleViewModel.isTop = item.IsTop;
                articleListJsonModel.data.Add(articleViewModel);
            }
            return articleListJsonModel;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPY.DB.Model;
using SPY.IRepository;
using SPY.View.Model;

namespace SPY.Site.ViewComponents
{
    public class CommentViewComponent: ViewComponent
    {
        private readonly ICommentManager _commentManager;
        public CommentViewComponent(ICommentManager commentManager)
        {
            _commentManager = commentManager;
        }
        public IViewComponentResult Invoke(int articleId)
        {
            CommentListViewModel commentListViewModel = new CommentListViewModel();
            var commentList =_commentManager.LoadEntities(x => x.ArticleId == articleId).ToList();
            commentListViewModel.ArticleId = articleId;
            commentListViewModel.List = commentList;
            return View("CommentList", commentListViewModel);
        }
    }
}

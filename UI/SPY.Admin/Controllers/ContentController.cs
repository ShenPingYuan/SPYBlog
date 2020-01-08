using System;
using Microsoft.AspNetCore.Mvc;
using SPY.DB.Model;
using SPY.Core;
using SPY.IRepository;
using System.Linq;
using SPY.View.Model;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace SPY.Admin.Controllers
{
    [Authorize]
    public class ContentController : Controller
    {
        private readonly UserManager<ApplicationIdentityUser> _userManager;
        private readonly IArticleManager _articleManager;
        private readonly ISiteInfoManager _siteInfoManager;
        private readonly ILatestNewsManager _latestNewsManager;
        private readonly ICategoryManager _categoryManager;

        public ContentController(IArticleManager articleManager, ISiteInfoManager siteInfoManager,
            UserManager<ApplicationIdentityUser> userManager,
            ILatestNewsManager latestNewsManager,
            ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
            _articleManager = articleManager;
            _userManager = userManager;
            _siteInfoManager = siteInfoManager;
            _latestNewsManager = latestNewsManager;
        }
        public IActionResult SiteInfo()
        {
            SiteInfo siteinfo = _siteInfoManager.GetAllEntities().FirstOrDefault();
            if (siteinfo == null)
            {
                siteinfo = new SiteInfo();
            }
            return View(siteinfo);
        }
        [HttpPut]
        public IActionResult UpdateSiteInfo(SiteInfo siteInfo)
        {
            if (siteInfo != null)
            {
                var dbSiteInfo = _siteInfoManager.GetAllEntities().FirstOrDefault();
                if (dbSiteInfo != null)
                {
                    dbSiteInfo.CenterTitle = siteInfo.CenterTitle;
                    dbSiteInfo.Motto = siteInfo.Motto;
                    dbSiteInfo.Views = siteInfo.Views;
                    if (_siteInfoManager.EditEntity(dbSiteInfo))
                    {
                        return Json("SUCCESS");
                    }
                }
            }
            return Json("FALSE");
        }
        public IActionResult LatestNews()
        {
            return View();
        }
        public async Task<IActionResult> LatestNewses()
        {
            var newses = await _latestNewsManager.GetAllEntities().ToListAsync();
            if (newses == null)
            {
                return Json(new { code = 1, count = 0, msg = "FALSE", data = string.Empty });
            }
            var data = new List<object>();
            for (int i = 0; i < newses.Count; i++)
            {
                data.Add(new
                {
                    RowId = i + 1,
                    NewsId = newses[i].Id,
                    NewsName = newses[i].NewsName,
                    NewsUrl = newses[i].NewsUrl,
                    IsOpen = newses[i].IsOpen,
                });
            }
            return Json(new { code = 0, count = data.Count, msg = "SUCCESS", data = data });
        }
        [HttpGet]
        public IActionResult AddLatestNews(int latestNewsId)
        {
            LatestNews news = new LatestNews();
            if (latestNewsId == 0)
            {
                return View(news);
            }
            news = _latestNewsManager.LoadEntities(x => x.Id == latestNewsId).FirstOrDefault();
            if (news == null)
            {
                news = new LatestNews();
            }
            return View(news);
        }
        [HttpPost]
        public IActionResult AddLatestNews(LatestNews latestNews)
        {
            if (latestNews == null)
            {
                return Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
            }
            var news = _latestNewsManager.LoadEntities(x => x.Id == latestNews.Id).FirstOrDefault();
            if (news != null)
            {
                news.IsOpen = latestNews.IsOpen;
                news.NewsName = latestNews.NewsName;
                news.NewsUrl = latestNews.NewsUrl;
                if (_latestNewsManager.EditEntity(news))
                {
                    return Json(new { code = 0, msg = "SUCCESS", count = 1, data = string.Empty });
                }
            }
            news = new LatestNews()
            {
                IsOpen = latestNews.IsOpen,
                NewsName = latestNews.NewsName,
                NewsUrl = latestNews.NewsUrl,
            };
            var result = _latestNewsManager.AddEntity(news);
            if (result != null)
            {
                return Json(new { code = 0, msg = "SUCCESS", count = 1, data = string.Empty });
            }
            return Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
        }
        public IActionResult DeleteLatestNews(int latestNewsId)
        {
            if (latestNewsId != 0)
            {
                var news = _latestNewsManager.LoadEntities(x => x.Id == latestNewsId).FirstOrDefault();
                if (news != null)
                {
                    if (_latestNewsManager.DeleteEntity(news))
                    {
                        return Json(new { code = 0, msg = "SUCCESS", count = 1, data = string.Empty });
                    }
                }
            }
            return Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AddArticle(int articleId)
        {
            AddArticleViewModel addArticleViewModel = new AddArticleViewModel();
            var categories = await _categoryManager.GetAllEntities().ToListAsync();
            for (int i = 0; i < categories.Count; i++)
            {
                addArticleViewModel.CategoryViews.Add(new CategoryViewModel
                {
                    CategoryName=categories[i].CategoryName,
                    ParentCategoryName=categories[i].ParentCategoryName,
                    Id=categories[i].Id
                });
            }
            if (articleId == 0)
            {
                return View("AddArticle", addArticleViewModel);
            }
            var article = _articleManager.LoadEntities(x => x.Id == articleId).FirstOrDefault();
            if (article != null)
            {
                addArticleViewModel.Author = article.Author;
                addArticleViewModel.content = article.Content;
                addArticleViewModel.newsImg = article.ImageUrl;
                addArticleViewModel.description = article.description;
                addArticleViewModel.newsTop = article.IsTop.ToString();
                addArticleViewModel.classify = article.Category;
                addArticleViewModel.newsTime = article.AddTime;
                addArticleViewModel.newsName = article.Title;
                addArticleViewModel.articleId = article.Id.ToString();
                addArticleViewModel.isTop = article.IsTop;
            }
            return View("AddArticle", addArticleViewModel);
        }
        public IActionResult ArticleList()
        {
            var articlelist = _articleManager.GetAllEntities().ToList();
            var result = Helper.HttpJsonResult(articlelist);
            return new JsonResult(result);
        }
        public IActionResult Test()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddArticle([FromBody]AddArticleViewModel addArticleViewModel)
        {
            if (addArticleViewModel == null)
            {
                return Json("失败");
            }
            Article article;
            if (addArticleViewModel.articleId == "")
            {
                var author = await _userManager.FindByNameAsync(addArticleViewModel.authorName);
                if (author != null)
                {
                    article = new Article
                    {
                        Title = addArticleViewModel.newsName,
                        AddTime = addArticleViewModel.newsTime,
                        Content = addArticleViewModel.content,
                        description = addArticleViewModel.description,
                        Category = addArticleViewModel.classify,
                        IsTop = addArticleViewModel.newsTop == "true" ? true : false,
                        ImageUrl = addArticleViewModel.newsImg,
                        UserId = author.Id,
                        Author = author,
                        Sort = "置顶",
                        CategoryId=2,
                    };
                    _articleManager.AddEntity(article);
                    return Json("添加成功");
                }
            }
            else
            {
                article = _articleManager.LoadEntities(x => x.Id == Convert.ToInt32(addArticleViewModel.articleId)).FirstOrDefault();
                if (article == null)
                {
                    return Json("失败");
                }
                article.Title = addArticleViewModel.newsName;
                article.Content = addArticleViewModel.content;
                article.description = addArticleViewModel.description;
                article.Category = addArticleViewModel.classify;
                article.IsTop = addArticleViewModel.newsTop == "true" ? true : false;
                article.ImageUrl = addArticleViewModel.newsImg;
                var result = _articleManager.EditEntity(article);
                if (result)
                {
                    return Json("修改成功");
                }
            }
            return Json("失败");
        }

        [HttpPost]
        public IActionResult DeleteContent(int contentId)
        {
            if (contentId == 0)
            {
                return Json("失败");
            }
            var article = _articleManager.LoadEntities(x => x.Id == contentId).FirstOrDefault();
            if (article != null)
            {
                var result = _articleManager.DeleteEntity(article);
                if (result)
                {
                    return Json("成功");
                }
            }
            return Json("失败");
        }
    }
}
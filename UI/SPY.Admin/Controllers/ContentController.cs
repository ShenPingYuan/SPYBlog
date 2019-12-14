using System;
using Microsoft.AspNetCore.Mvc;
using SPY.DB.Model;
using SPY.Core;
using SPY.IRepository;
using System.Linq;
using SPY.View.Model;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SPY.Admin.Controllers
{

    public class ContentController : Controller
    {
        private readonly UserManager<ApplicationIdentityUser> _userManager;
        private readonly IArticleManager _articleManager;
        private readonly ISiteInfoManager _siteInfoManager;

        public ContentController(IArticleManager articleManager, ISiteInfoManager siteInfoManager, UserManager<ApplicationIdentityUser> userManager)
        {
            _articleManager = articleManager;
            _userManager = userManager;
            _siteInfoManager = siteInfoManager;
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
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddArticle(int articleId)
        {
            AddArticleViewModel addArticleViewModel = new AddArticleViewModel();
            if (articleId == 0)
            {
                return View("AddArticle",addArticleViewModel);
            }
            var article = _articleManager.LoadEntities(x => x.Id == articleId).FirstOrDefault();
            if(article!=null)
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
            return View("AddArticle",addArticleViewModel);
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
            if (addArticleViewModel.articleId=="")
            {
                var author =await _userManager.FindByNameAsync(addArticleViewModel.authorName);
                if(author!=null)
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
                        UserId=author.UserId,
                        Author = author,
                    };
                _articleManager.AddEntityAsync(article);
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
            var article = _articleManager.LoadEntities(x=>x.Id== contentId).FirstOrDefault();
            if(article!=null)
            {
                var result = _articleManager.DeleteEntity(article);
                if(result)
                {
                    return Json("成功");
                }
            }
            return Json("失败");
        }
    }
}
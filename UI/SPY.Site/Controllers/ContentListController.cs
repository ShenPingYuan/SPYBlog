using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SPY.DB.Model;
using SPY.IRepository;
using SPY.View.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPY.Site.Controllers
{
    public class ContentListController:Controller
    {
        private readonly IArticleManager _articleManager;
        public ContentListController(IArticleManager articleManager)
        {
            _articleManager = articleManager;
        }
        public IActionResult ArticleList(string category)
        {
            var articleList =_articleManager.LoadEntities(x => x.Category == category).Include(x=>x.Author).ToList();
            List<ArticleViewModel> viewModels = new List<ArticleViewModel>();
            for (int i = 0; i < articleList.Count; i++)
            {
                viewModels.Add(new ArticleViewModel
                {
                    Author = articleList[i].Author,
                    articleImg = articleList[i].ImageUrl,
                    articleTitle = articleList[i].Title,
                    description = articleList[i].description,
                    publishDateTime = articleList[i].AddTime,
                    isTop = articleList[i].IsTop,
                    articleID = articleList[i].Id,
                    category=articleList[i].Category
                });
            }
            return View(viewModels);
        }
        public IActionResult ArticleSearch(string keyWords)
        {
            List<ArticleViewModel> viewModels = new List<ArticleViewModel>();
            if (keyWords==null||keyWords=="")
            {
                return View(viewModels);
            }
            var articleList = _articleManager.LoadEntities(
                x => EF.Functions.Like(x.Title, $"%{keyWords}%") ||
                x.Content.Contains(keyWords) ||
                x.Author.NickName.Contains(keyWords) ||
                x.Category.Contains(keyWords) ||
                x.description.Contains(keyWords) ||
                x.AddTime.ToString().Contains(keyWords)
                ).Include(x => x.Author).ToList();
            for (int i = 0; i < articleList.Count; i++)
            {
                viewModels.Add(new ArticleViewModel
                {
                    Author = articleList[i].Author,
                    articleImg = articleList[i].ImageUrl,
                    articleTitle = articleList[i].Title,
                    description = articleList[i].description,
                    publishDateTime = articleList[i].AddTime,
                    isTop = articleList[i].IsTop,
                    articleID = articleList[i].Id,
                    category = articleList[i].Category
                });
            }
            return View("ArticleList", viewModels);
        }
        public ActionResult BigArticleList(int pageIndex)
        {
            int totalCount;
            if (pageIndex == 0)
            {
                return Ok(new { code = 1, count = 0, msg = "失败", data = string.Empty });
            }
            var articlelist = _articleManager.LoadPageEntities<int>(pageIndex, 4, out totalCount, x => x.IsTop, x => x.Id, false).Select(x=>new {
                x.Title,
                x.AddTime,
                x.description,
                x.ImageUrl,
                x.Id,
                x.Author.NickName,
                x.ViewCount,
                x.Author.UserFaceImgUrl,
                CommentCount=x.Comments.Count
            }).ToList();
            if (articlelist!=null)
            {
                //处理循环引用问题
                //JsonSerializerSettings settings = new JsonSerializerSettings {
                //    ReferenceLoopHandling=ReferenceLoopHandling.Ignore,
                //};
                //JsonSerializerSettings settings = new JsonSerializerSettings();
                ////settings.MaxDepth = 2;
                //settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; //设置不处理循环引用
                return Json(new { code = 0, count = articlelist.Count, msg = "成功", data = articlelist });
            }
            return Ok(new { code = 1, count = 0, msg = "失败", data = string.Empty });
        }
        public async Task<IActionResult> LastestArticle(int topCount)
        {
            if(topCount==0)
            {
                return Ok(new { code = 1, count = 0, msg = "失败", data = string.Empty });
            }
            int totalCount;
            var articles =await _articleManager.LoadEntities(topCount, out totalCount, x => true, x => x.Id, false).Select(x=>new {
                x.Title,
                x.ImageUrl,
                x.Id,
                x.ViewCount
            }).ToListAsync();
            if(articles!=null)
            {
                return Ok(new { code = 0, count = articles.Count, msg = "成功", data = articles });
            }
            return Ok(new { code = 1, count = 0, msg = "失败", data = string.Empty });
        }
        public async Task<IActionResult> HotArticle(int topCount)
        {
            if (topCount == 0)
            {
                return Ok(new { code = 1, count = 0, msg = "失败", data = string.Empty });
            }
            int totalCount;
            var articles = await _articleManager.LoadEntities(topCount, out totalCount, x => true, x => x.ViewCount, false).Select(x => new {
                x.Title,
                x.ImageUrl,
                x.Id,
                x.ViewCount
            }).ToListAsync();
            if (articles != null)
            {
                return Ok(new { code = 0, count = articles.Count, msg = "成功", data = articles });
            }
            return Ok(new { code = 1, count = 0, msg = "失败", data = string.Empty });
        }
        public async Task<IActionResult> LifeCircle(int topCount,string category)
        {
            if (topCount == 0||category==null)
            {
                return Ok(new { code = 1, count = 0, msg = "失败", data = string.Empty });
            }
            int totalCount;
            var articles = await _articleManager.LoadEntities(topCount, out totalCount, x=>x.Category== category, x => x.Id, false).ToListAsync();
            List<ArticleViewModel> articleViews = new List<ArticleViewModel>();
            for (int i = 0; i < articles.Count; i++)
            {
                articleViews.Add(new ArticleViewModel
                {
                    articleID=articles[i].Id,
                    articleImg=articles[i].ImageUrl,
                });
            }
            if (articles != null)
            {
                return Ok(new { code = 0, count = articles.Count, msg = "成功", data = articleViews });
            }
            return Ok(new { code = 1, count = 0, msg = "失败", data = string.Empty });
        }
    }
}

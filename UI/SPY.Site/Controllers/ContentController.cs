using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SPY.IRepository;
using SPY.View.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace SPY.Site.Controllers
{
    public class ContentController : Controller
    {
        private readonly IArticleManager _articleManager;
        private readonly IHttpClientFactory _httpClient;
        private readonly ILatestNewsManager _latestNewsManager;
        private readonly IConfiguration _configuration;
        public ContentController(IArticleManager articleManager,
            IHttpClientFactory httpClient,
            ILatestNewsManager latestNewsManager,
            IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _articleManager = articleManager;
            _latestNewsManager = latestNewsManager;
        }
        public string GetFileUploadDomain()
        {
            return _configuration["UpLoadFilesDomain"];
        }
        public async Task<IActionResult> NewsList()
        {
            var newses =await _latestNewsManager.GetAllEntities().ToListAsync();
            if (newses != null)
            {
                return Json(new { code = 0, msg = "SUCCESS", count = newses.Count, data = newses });
            }
            return Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
        }
        public IActionResult ArticleContent(int id)
        {
            ArticleViewModel articleView = new ArticleViewModel();
            if (id == 0)
            {
                return View(articleView);
            }
            var article = _articleManager.LoadEntities(x => x.Id == id).Select(x => new {
                AuthorName = x.Author.NickName,
                Title = x.Title,
                x.AddTime,
                x.Content,
                x.ViewCount,
                x.Category,
                ArticleId = x.Id,
                x.SupportCounts,
            }).FirstOrDefault();
            if (article == null)
            {
                return View(articleView);
            }
            articleView = new ArticleViewModel
            {
                AuthorName = article.AuthorName,
                articleTitle = article.Title,
                publishTime = article.AddTime.ToString("yyyy年MM月dd日 HH:mm:ss"),
                articleContent = article.Content.Replace(@"/upload", GetFileUploadDomain() + @"/upload"),
                viewCount = article.ViewCount,
                category = article.Category,
                articleID = article.ArticleId,
                supportCount = article.SupportCounts,
            };
            ViewData["Title"] = articleView.articleTitle;
            return View("ArticleContent", articleView);
        }
        public IActionResult NavContent(string title)
        {
            ArticleViewModel articleView = new ArticleViewModel();
            if (title == null)
            {
                return View("ArticleContent", articleView);
            }
            var article = _articleManager.LoadEntities(x => x.Title == title).Select(x=>new { 
                AuthorName=x.Author.NickName,
                Title=x.Title,
                x.AddTime,
                x.Content,
                x.ViewCount,
                x.Category,
                ArticleId=x.Id,
                x.SupportCounts,
            }).FirstOrDefault();
            if (article == null)
            {
                return View("ArticleContent", articleView);
            }
            articleView = new ArticleViewModel
            {
                AuthorName = article.AuthorName,
                articleTitle = article.Title,
                publishTime = article.AddTime.ToString("yyyy年MM月dd日 HH:mm:ss"),
                articleContent = article.Content.Replace(@"/upload", GetFileUploadDomain() + @"/upload"),
                viewCount = article.ViewCount,
                category = article.Category,
                articleID = article.ArticleId,
                supportCount = article.SupportCounts,
            };
            ViewData["Title"] = articleView.articleTitle;
            return View("ArticleContent", articleView);
        }
        [HttpPut]
        public IActionResult SupportClick(int articleId)
        {
            if (articleId != 0)
            {
                var article = _articleManager.LoadEntities(x => x.Id == articleId).FirstOrDefault();
                if (article != null)
                {
                    article.SupportCounts++;
                    if (_articleManager.EditEntity(article))
                    {
                        return Json(new { code = 0, msg = "SUCCEED", count = 1, data = string.Empty });
                    }
                }
            }
            return Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
        }
        public async Task<IActionResult> GetUserInfo(string qq)
        {
            var nickName = "";
            try
            {
                var client = _httpClient.CreateClient();
                string result = await client.GetStringAsync("https://api.toubiec.cn/qq?qq="+qq+"&size=100");
                int errorFirst = result.IndexOf("200");
                if (errorFirst == -1)
                {
                    return Json("不存在该QQ号");
                }
                int first1 = result.IndexOf("name") + 7;
                int first2 = result.IndexOf("}") - 1;
                nickName = result.Substring(first1, first2 - first1);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return Json(nickName);
        }
    }
}

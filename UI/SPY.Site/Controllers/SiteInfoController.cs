using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPY.DB.Model;
using SPY.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPY.Site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteInfoController : ControllerBase
    {
        private readonly ISiteInfoManager _siteInfoManager;
        private readonly IArticleManager _articleManager;
        private readonly ITagManager _tagManager;
        private readonly ICommentManager _commentManager;
        private readonly ICategoryManager _categoryManager;
        public SiteInfoController(ISiteInfoManager siteInfoManager,
            IArticleManager articleManager,
            ITagManager tagManager,
            ICommentManager commentManager,
            ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
            _siteInfoManager = siteInfoManager;
            _articleManager = articleManager;
            _commentManager = commentManager;
            _tagManager = tagManager;
        }
        [HttpGet]
        public IActionResult SiteInfo()
        {
            SiteInfo info = _siteInfoManager.GetAllEntities().FirstOrDefault();
            if(info==null)
            {
                info = new SiteInfo();
            }
            info.Views++;
            if (info == null)
            {
                return Ok(new { code = 1, count = 0, msg = "失败", data = string.Empty });
            }
            return Ok(new { code = 0, count = 1, msg = "成功", data = info });
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSiteInfo()
        {
            SiteInfo info = _siteInfoManager.GetAllEntities().FirstOrDefault();
            if (info == null)
            {
                info = new SiteInfo();
            }
            info.ArticleCount = _articleManager.GetAllEntities().Count();
            info.TagCount = _tagManager.GetAllEntities().Count();
            info.CommentCount = _commentManager.GetAllEntities().Count();
            info.ColumnCount = (await _categoryManager.GetAllEntities().ToListAsync()).Count;//死数据，后期改
            info.Views++;
            var result = _siteInfoManager.EditEntity(info);
            if (result)
            {
                return Ok(new { code = 0, count = 1, msg = "成功", data = info });
            }
            return Ok(new { code = 1, count = 0, msg = "失败", data = string.Empty });
        }
    }
}

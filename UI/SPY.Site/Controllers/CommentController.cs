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
    public class CommentController:Controller
    {
        private readonly ICommentManager _commentManager;
        public CommentController(ICommentManager commentManager)
        {
            _commentManager = commentManager;
        }
        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            if(comment!=null)
            {
                Comment result = _commentManager.AddEntity(comment);
                return Json(new { code = 0, count = 1 ,msg="成功",data=result}) ;
            }
            return Json(new{code = 0, count = 1, msg = "失败", data = new { } });
        }
        public async Task<IActionResult> CommentList(int topCount)
        {
            var commentList =await _commentManager.LoadEntities(topCount, out int totalCount, x => true, x => x.CommentId, false).ToListAsync();
            if(commentList!=null)
            {
                return Ok(new { code = 0, count = commentList.Count, msg = "成功", data = commentList });
            }
            return Ok(new { code = 1, count = 0, msg = "失败", data = string.Empty});
        }
        [HttpPut]
        public IActionResult SupportClick(int commentId)
        {
            if (commentId != 0)
            {
                var comment = _commentManager.LoadEntities(x=>x.CommentId==commentId).FirstOrDefault();
                if (comment != null)
                {
                    comment.Supports++;
                    if (_commentManager.EditEntity(comment))
                    {
                        return Json(new { code = 0, msg = "SUCCEED", count = 1, data = string.Empty });
                    }
                }
            }
            return Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
        }
    }
}

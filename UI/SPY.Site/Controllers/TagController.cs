using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPY.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPY.Site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController:ControllerBase
    {
        private readonly ITagManager _tagManager;
        public TagController(ITagManager tagManager)
        {
            _tagManager = tagManager;
        }
        [HttpGet]
        public async Task<IActionResult> Tags()
        {
            var tags =await _tagManager.LoadEntities(x=>x.IsOpen==true).ToListAsync();
            if(tags==null)
            {
                return Ok(new { code = 0, count = tags.Count, msg = "成功", data = tags });
            }
            return Ok(new { code = 0, count = tags.Count, msg = "成功", data = tags });
        }
    }
}

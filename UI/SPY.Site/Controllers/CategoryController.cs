using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPY.IRepository;
using SPY.View.Model;

namespace SPY.Site.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryManager _categoryManager;
        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }
        public async Task<ActionResult<IEnumerable<CategoryViewModel>>> Categories()
        {
            var categories = await _categoryManager.GetAllEntities().ToListAsync();
            //var datas = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);
            var datas = new List<Object>();
            for (int i = 0; i < categories.Count; i++)
            {
                datas.Add(new
                {
                    ShowId = i + 1,
                    Id = categories[i].Id,
                    ParentCategoryName = categories[i].ParentCategoryName,
                    CategoryName = categories[i].CategoryName,
                });
            }
            return Ok(new { code = 0, msg = "分类栏目", count = datas.Count, data = datas });
        }
    }
}
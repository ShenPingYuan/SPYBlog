using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPY.DB.Model;
using SPY.IRepository;
using SPY.View.Model;

namespace SPY.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryManager _categoryManager;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryManager categoryManager, IMapper mapper)
        {
            _categoryManager = categoryManager;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
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
        [HttpGet]
        public IActionResult AddCategory(int categoryId)
        {
            CategoryViewModel viewModel = new CategoryViewModel();
            var category = _categoryManager.LoadEntities(x => x.Id == categoryId).FirstOrDefault();
            if (category != null)
            {
                viewModel.Id = category.Id;
                viewModel.CategoryName = category.CategoryName;
                viewModel.ParentCategoryName = category.ParentCategoryName;
            }
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult AddCategory(CategoryViewModel category)
        {
            if (category == null)
            {
                return Ok(new { code = 1, msg = "FALSE", count = 1, data = string.Empty });
            }
            Category dbCategory;
            dbCategory = _categoryManager.LoadEntities(x => x.Id == category.Id).FirstOrDefault();
            if (dbCategory == null)
            {
                dbCategory = new Category
                {
                    CategoryName = category.CategoryName,
                    ParentCategoryName = category.ParentCategoryName,
                };
                var result = _categoryManager.AddEntity(dbCategory);
                if (result != null)
                {
                    return Ok(new { code = 0, msg = "SUCCEED", count = 1, data = string.Empty });
                }
            }
            else
            {
                dbCategory.CategoryName = category.CategoryName;
                dbCategory.ParentCategoryName = category.ParentCategoryName;
                var result = _categoryManager.EditEntity(dbCategory);
                if (result)
                {
                    return Ok(new { code = 0, msg = "SUCCEED", count = 1, data = string.Empty });
                }
            }
            return Ok(new { code = 1, msg = "FALSE", count = 1, data = string.Empty });
        }
        [HttpPost]
        public IActionResult DeleteCategory(int categoryId)
        {
            if (categoryId == 0)
            {
                return NotFound(new { code = 1, msg = "分类栏目Id为0,删除失败", count = 0, data = string.Empty });
            }
            var category = _categoryManager.LoadEntities(x => x.Id == categoryId).FirstOrDefault();
            if (category == null)
            {
                return NotFound(new { code = 1, msg = $"未找到Id为{categoryId}的分类栏目,删除失败", count = 0, data = string.Empty });
            }
            var result = _categoryManager.DeleteEntity(category);
            if (result)
            {
                return Ok(new { code = 0, msg = "SUCCEED", count = 1, data = string.Empty });
            }
            return Ok(new { code = 1, msg = "FALSE", count = 1, data = string.Empty });
        }
    }
}
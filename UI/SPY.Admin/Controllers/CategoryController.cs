using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPY.IRepository;

namespace SPY.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryManager _categoryManager;
        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Categories()
        {
            var categories =await _categoryManager.GetAllEntities().ToListAsync();
            return Ok();
        }
    }
}
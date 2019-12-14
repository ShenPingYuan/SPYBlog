using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SPY.View.Model;
using SPY.DB.Model;

namespace SPY.Admin.Controllers
{
    public class RoleController : Controller
    {
        private readonly UserManager<ApplicationIdentityUser> _userManager;
        private readonly RoleManager<ApplicationIdentityRole> _roleManager;
        public RoleController(UserManager<ApplicationIdentityUser> userManager,
            RoleManager<ApplicationIdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            List<RoleInfoDataViewModel> roleData = new List<RoleInfoDataViewModel>();
            for (int i = 0; i < roles.Count; i++)
            {
                roleData.Add(new RoleInfoDataViewModel
                {
                    RowId = (i + 1).ToString(),
                    RoleId = roles[i].Id,
                    GradeIcon = "icon-vip" + (roles[i].Id),
                    RoleName = roles[i].Name,
                }) ;
            }
            return Json(new { code = 0, msg = "角色列表", count = roles.Count, data = roleData });
        }
        [HttpPost]
        public async Task<IActionResult> AddRole([FromBody]RoleAddViewModel roleAddViewModel)
        {
            var role = new ApplicationIdentityRole
            {
                Id = roleAddViewModel.RoleID,
                Name = roleAddViewModel.RoleName
            };
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return Json("SUCCEED");
            }
            return Json("角色添加失败!");
        }
        [HttpPost]
        public async Task<IActionResult> RoleDelete(Int32 roleId,string roleName)
        {
            //var roleId = Convert.ToInt32(Request.Form["roleId"]);
            if(roleId>0)
            {
                var role = await _roleManager.FindByNameAsync(roleName);
                if(role!=null)
                {
                    var result=await _roleManager.DeleteAsync(role);
                    if(result.Succeeded)
                    {
                        return Json("删除成功!");
                    }
                }
            }
            return Json("删除失败!");
        }

    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPY.DB.Model;
using SPY.View.Model;

namespace SPY.Admin.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationIdentityUser> _signInManager;
        private readonly UserManager<ApplicationIdentityUser> _userManager;
        private readonly RoleManager<ApplicationIdentityRole> _roleManager;

        public AccountController(SignInManager<ApplicationIdentityUser> signInManager,
            UserManager<ApplicationIdentityUser> userManager,
            RoleManager<ApplicationIdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult UserList()
        {
            return View();
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            List<UserInfoViewModel> userViewModels = new List<UserInfoViewModel>();
            for (int i = 0; i < users.Count; i++)
            {
                userViewModels.Add(new UserInfoViewModel
                {
                    UsersId = i + 1,
                    NickName=users[i].NickName,
                    UserName=users[i].UserName,
                    UserSex=users[i].Sex,
                    UserEmail=users[i].Email,
                    UserDesc=users[i].UserDescription,
                    UserGrade=users[i].RoleName,
                    UserEndTime=users[i].EndTime,
                    UserStatus=users[i].IsInUsing
                }) ;
            }
            return Json(new { code = 0, msg = "成功", count = users.Count, data = userViewModels });
        }

        public async Task<IActionResult> UserInfo(string userName)
        {
            UserInfoViewModel userInfoViewModel;
            if (userName==null)
            {
                userInfoViewModel = new UserInfoViewModel();
                return View(userInfoViewModel);
            }
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "用户查询出错");
                return View();
            }
            userInfoViewModel = new UserInfoViewModel
            {
               NickName=user.NickName,
               UserName=user.UserName,
               UserEmail=user.Email,
               UserSex=user.Sex,
               UserGrade=user.RoleName,
               Province=user.Province,
               City=user.City,
               Area=user.Area,
               BirthDate=user.BirthDate,
               RealName=user.RealName,
               PhoneNumber=user.PhoneNumber,
               UserDesc=user.UserDescription,
               UserFaceImgUrl=user.UserFaceImgUrl
            };
            return View(userInfoViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserInfoViewModel userInfoViewModel)
        {
            var user = await _userManager.FindByNameAsync(userInfoViewModel.UserName);
            if(user==null)
            {
                return Json("失败");
            }
            user.UserDescription = userInfoViewModel.UserDesc;
            user.RealName = userInfoViewModel.RealName;
            user.Province = userInfoViewModel.Province;
            user.City = userInfoViewModel.City;
            user.Area = userInfoViewModel.Area;
            user.BirthDate = userInfoViewModel.BirthDate;
            user.Email = userInfoViewModel.UserEmail;
            user.NickName = userInfoViewModel.NickName;
            user.PhoneNumber = userInfoViewModel.PhoneNumber;
            user.Sex = userInfoViewModel.UserSex;
            user.UserFaceImgUrl = userInfoViewModel.UserFaceImgUrl;
            var result = await _userManager.UpdateAsync(user);
            if(result.Succeeded)
            {
                return Json("成功");
            }
            return Json("失败");
        }
        public IActionResult ChangePwd(string userName)
        {
            return View("ChangePwd",userName);
        }
        [HttpPost]
        public async Task<IActionResult> ChangePwd(string userName,string oldPassword,string newPassword)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return Json("未查到用户");
            }
            var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            if(result.Succeeded)
            {
                return Json("SUCCEED");
            }
            return Json("失败");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userName)
        {
            if(userName==null)
            {
                return Json("失败");
            }
            var user = await _userManager.FindByNameAsync(userName);
            if(user!=null)
            {
                var result = await _userManager.DeleteAsync(user);
                if(result.Succeeded)
                {
                    return Json("成功");
                }
            }
            return Json("失败");
        }
        [HttpPost]
        public async Task<IActionResult> LoginApi(string userName,string password)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if(user==null)
            {
                return Json("用户不存在");
            }
            var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
            if(result.Succeeded)
            {
                return Json("SUCCEED");
            }
            return Json("失败");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            var user = await _userManager.FindByNameAsync(loginViewModel.UserName);
            if (user == null)
            {
                ModelState.AddModelError("UserName", "用户不存在");
                return View(loginViewModel);
            }
            var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
            if (result.Succeeded)
            {
                user.EndTime = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
                var updateResult = await _userManager.UpdateAsync(user);
                if(updateResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("UserName", "登录失败！");
            return View(loginViewModel);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationIdentityUser()
                {
                    UserName = registerViewModel.UserName
                };
                var result = await _userManager.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded)
                {
                   return RedirectToAction("Login", "Account");
                }
            }

            return View(registerViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        public async Task<IActionResult> AddUser(string userName)
        {
            UserInfoViewModel userInfoViewModel;
            if (userName!=null)
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    userInfoViewModel = new UserInfoViewModel
                    {
                        NickName=user.NickName,
                        UserDesc=user.UserDescription,
                        UserEmail=user.Email,
                        UserGrade=user.RoleName,
                        UserSex=user.Sex,
                        UserName=user.UserName,
                        UserStatus=user.IsInUsing
                    };
                    return View(userInfoViewModel);
                }
            }
            userInfoViewModel = new UserInfoViewModel();
            return View(userInfoViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserViewModel addUserViewModel)
        {
            addUserViewModel.CreateTime = DateTime.Now.ToLocalTime();
            var user = await _userManager.FindByNameAsync(addUserViewModel.UserName);
            if (user==null)
            {
                var result = await _userManager.CreateAsync(new ApplicationIdentityUser
                {
                    UserName = addUserViewModel.UserName,
                    CreateTime = addUserViewModel.CreateTime,
                    Sex=addUserViewModel.Sex,
                    Email=addUserViewModel.Email,
                    NickName=addUserViewModel.NickName,
                    IsInUsing=addUserViewModel.IsInUsing,
                    RoleName=addUserViewModel.RoleName,
                    UserDescription=addUserViewModel.UserDescription
                }, addUserViewModel.Password);
                if(result.Succeeded)
                {
                    user =await _userManager.FindByNameAsync(addUserViewModel.UserName);
                    if(user==null)
                    {
                        return Json("失败");
                    }
                    var role = await _roleManager.FindByIdAsync(addUserViewModel.RoleId);
                    if(role==null)
                    {
                        role = new ApplicationIdentityRole
                        {
                            Id=addUserViewModel.RoleId,
                            Name=addUserViewModel.RoleName
                        };
                        var roleresult = await _roleManager.CreateAsync(role);
                        if(roleresult.Succeeded)
                        {
                            role = await _roleManager.FindByIdAsync(role.Id);
                            if(role!=null)
                            {
                                var addToRoleResult =await _userManager.AddToRoleAsync(user,role.Name);
                                if(addToRoleResult.Succeeded)
                                {
                                    return Json("成功");
                                }
                            }
                        }
                        return Json("失败");
                    }
                    var addToRoleResult1 = await _userManager.AddToRoleAsync(user, role.Name);
                    if(addToRoleResult1.Succeeded)
                    {
                        return Json("成功");
                    }
                }
            }
            else
            {
                user.UserName = addUserViewModel.UserName;
                user.Email = addUserViewModel.Email;
                user.NickName = addUserViewModel.NickName;
                user.IsInUsing = addUserViewModel.IsInUsing;
                user.RoleName = addUserViewModel.RoleName;
                user.Sex = addUserViewModel.Sex;
                user.UserDescription = addUserViewModel.UserDescription;
                var result = await _userManager.UpdateAsync(user);
                if(result.Succeeded)
                {
                    var role = await _roleManager.FindByIdAsync(addUserViewModel.RoleId);
                    if(role==null)
                    {
                        role = new ApplicationIdentityRole
                        {
                            Id = addUserViewModel.RoleId,
                            Name=addUserViewModel.RoleName
                        };
                        var roleResult = await _roleManager.CreateAsync(role);
                        if(!roleResult.Succeeded)
                        {
                            return Json("失败");
                        }
                        var addToRoleResult = await _userManager.AddToRoleAsync(user, role.Name);
                        if(addToRoleResult.Succeeded)
                        {
                            return Json("成功");
                        }
                    }
                    else
                    {
                        var addToRoleResult = await _userManager.AddToRoleAsync(user, role.Name);
                        if (addToRoleResult.Succeeded)
                        {
                            return Json("成功");
                        }
                    }
                }
            }
            return Json("失败");
        }
        public async Task<IActionResult> UserFaceImage(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if(user!=null)
            {
                return Content(user.UserFaceImgUrl);
            }
            return Content("失败");
        }
        public async Task<IActionResult> UserCount()
        {
            var users =await _userManager.Users.ToListAsync();
            return Json(new { count = users.Count });
        }
    }
}
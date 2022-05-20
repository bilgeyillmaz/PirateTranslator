using CaseAFS.DataAccess;
using CaseAFS.Models;
using CaseAFS.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CaseAFS.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly CaseAfsDbContext _caseAfsDbContext;

        public AccountController(CaseAfsDbContext caseAfsDbContext)
        {
            _caseAfsDbContext = caseAfsDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index([Bind("Email", "Password")] UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                    ClaimsIdentity identiy = null;
                    bool isAuthenticated = false;
                    User user = await _caseAfsDbContext.Users.Include(k => k.Role).FirstOrDefaultAsync(m => m.Email == userViewModel.Email && m.Password == userViewModel.Password);
                    if (user == null)
                    {
                        ModelState.AddModelError("Error1", "User not found.");
                        return View();
                    }

                    identiy = new ClaimsIdentity(
                        new[]
                        {
                        new Claim(ClaimTypes.Sid,user.UserId.ToString()),
                        new Claim(ClaimTypes.Email,user.Email),
                        new Claim(ClaimTypes.Role,user.Role.RoleName),
                        }, CookieAuthenticationDefaults.AuthenticationScheme
                        );
                    isAuthenticated = true;
                    if (isAuthenticated)
                    {
                        var claim = new ClaimsPrincipal(identiy);
                        var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claim,

                            new AuthenticationProperties
                            {
                                IsPersistent = true,
                                ExpiresUtc = DateTime.Now.AddMinutes(60)
                            });

                        if (user.Role.RoleName == "Admin")
                        {
                            return Redirect("~/User/Index");
                        }
                        else if (user.Role.RoleName == "Member")
                        {
                            return Redirect("~/Translation/Index");
                        }
                        else
                        {
                        return Redirect("~/Home/ErrorPage");
                        }
                    }
            }
            return View(userViewModel);
        }
        public  async  Task< IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                _caseAfsDbContext.Users.Add(user);
                user.RoleId = 2;
                _caseAfsDbContext.SaveChanges();
                ModelState.Clear();
                ViewBag.Message = user.FirstName + " " + user.LastName + " " + "successfully registered."; 
            }
            return View();
        }
        
    }
}

using CaseAFS.DataAccess;
using CaseAFS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq; 
namespace CaseAFS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly CaseAfsDbContext _caseAfsDbContext;

        public UserController(CaseAfsDbContext caseAfsDbContext)
        {
            _caseAfsDbContext = caseAfsDbContext;
        }
        public IActionResult Index()
        {
                var result = from user in _caseAfsDbContext.Users
                             from role in _caseAfsDbContext.Roles.Where(r => r.RoleId == user.RoleId).ToList()
                             select new User()
                             {
                                 UserId = user.UserId,
                                 RoleId = role.RoleId,
                                 Email = user.Email,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Password = user.Password,
                                 PasswordRepeat = user.PasswordRepeat,
                                 PhoneNumber = user.PhoneNumber,
                                 Role =(role == null)?null: new Role()
                                 {
                                     RoleId = role.RoleId,
                                     RoleName = role.RoleName
                                 }
                             };
                return View(result.ToList());
        }
    }
}

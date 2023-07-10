using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using task1.Models;

namespace task1.Controllers
{
    public class LoginController : Controller
    {
        task1Context db = new task1Context();
        public IActionResult Index()
        {
            return View();


        }
  
        public void Index(User u)
        {
            var users = db.User1s.Join(
                db.Statuses,
                u => u.Id,
                s => s.Id,
                (user, status) => new
                {
                    Id = user.Id,
                    Name = user.UserName,
                    Password = user.UserPassword,
                    UserStatus = status.StatusName
                }).SingleOrDefault(x => x.Name == u.UserName && x.Password == u.UserPassword);
            if (users.UserStatus == "Admin")
            {
                RedirectToAction("Index", "Admin");
            }
            else if (users.UserStatus == "User")
            {
                RedirectToAction("Index", "User");
            }



            if (users == null)
            {
                var claim = new List<Claim>(){
                    new Claim("Id",users.Id.ToString()),

                    new Claim(ClaimTypes.Name,users.Name),
                    new Claim(ClaimTypes.Role,users.UserStatus),
                };
                var identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal).Wait();
                RedirectToAction("Index", "Admin");
            }

        }
    }

        
        }
    


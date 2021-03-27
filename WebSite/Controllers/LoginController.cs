using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        static List<User> users = new List<User>()
        {
            new User()
            {
                UserID =1,
                UserName ="admin",
                Password = "1234",
                RoleID =1,
            }
            ,new User()
            {
                UserID =1,
                UserName ="admin",
                Password = "1234",
                RoleID =1,
            }
        };
        static List<Role> _role = new List<Role>(){
            new Role{RoleID=1,RoleName="Admin"},
            new Role{RoleID=1,RoleName="Visitor"}

        };
        public LoginController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Login(string username, string password)
        {

            if (username != null && password != null && username.Equals(username) && password.Equals(password))
            {
                HttpContext.Session.SetString("username", username);
                return View("Success");
            }
            else
            {
                ViewBag.error = "Invalid Account";
                return View("Index");
            }
        }
//
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}

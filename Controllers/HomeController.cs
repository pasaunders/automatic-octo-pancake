using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DbConnection;
using logReg.Models;

namespace logReg.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(ViewUser user)
        {
            if(ModelState.IsValid)
            {
                string firstName = user.firstName;
                string lastName = user.lastName;
                string email = user.email;
                string password = user.password;
                DbConnector.Execute($"INSERT INTO user(firstName, lastName, email, password) VALUES ({firstName}, {lastName}, {email}, {password});");
                return View("Register");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string firstName, string password)
        {
            List<Dictionary<string,object>> AllUsers = DbConnector.Query("SELECT * FROM users");
            int usercheck = AllUsers.FindIndex(item => item["firstName"] == firstName);
            if((usercheck >= 0) && (password == AllUsers[usercheck]["password"]))
            {
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}

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
        public IActionResult Register(Index pageData)
        {
            User registerData = pageData.user;
            TryValidateModel(registerData);
            if(ModelState.IsValid)
            {
                DbConnector.Execute($@"INSERT INTO user (firstName, lastName, email, password) VALUES ('{registerData.firstName}', '{registerData.lastName}', '{registerData.email}', '{registerData.password}');");
                return View("Register");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(Index pageData)
        {
            Login loginData = pageData.login;
            TryValidateModel(loginData);
            if (ModelState.IsValid)
            {
                List<Dictionary<string,object>> userCheck = DbConnector.Query($"SELECT * FROM user WHERE firstName='{loginData.firstName}';");
                if((userCheck.Count == 0) || ((string)userCheck[0]["password"] != loginData.password))
                {
                    return RedirectToAction("Index");
                }    
                return View("Login");
            }
            return RedirectToAction("Index");
        }
    }
}

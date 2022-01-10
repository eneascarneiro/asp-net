using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationLogin.Models;

namespace WebApplicationLogin.Controllers
{
    public class LoginControl : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult process_login(UserModel userModel)
        {
            if (userModel.UserName == "papa" && userModel.Password == "jones")
            {
                return View("LoginSuccess", userModel);
            }
            else
            {
                return View("LoginFailure", userModel);
            }
        }
    }
}

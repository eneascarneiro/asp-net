using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp1.Models;
using WebApp1.Servicios;

namespace WebApp1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            @ViewBag.Message = "este es el mensaje inicial para Index";
            return View();
        }

        public IActionResult Privacy()
        {
            @ViewBag.Author = "JMA Soluciones Informáticas S.L.";
            return View();
        }
        public IActionResult LoginFrm()
        {
                return View();

        }
        public IActionResult LoginSubmit(UserData userData)
        {
            SecurityService validador = new SecurityService();
            if (userData.userName == null || userData.password == null)
            {
                @ViewBag.Message = "Debe informar el usuario y/o el password";
                    return View("LoginFrm");
            }
            else if (validador.ValidarUsuario(userData))
            {
                return View("Contenido");
            } else 
            {
                @ViewBag.Message = "Usuario y/o password no válido";
                return View("LoginFrm");
            }
            
        }
        public IActionResult Contenido() 
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace crm.Controler
{
    public class HomeController : Controller
    {
        /*
         * https://www.c-sharpcorner.com/article/simple-login-application-using-Asp-Net-mvc/
         * 
         */
        public IActionResult Index()
        {
            return View();
        }
    }
}

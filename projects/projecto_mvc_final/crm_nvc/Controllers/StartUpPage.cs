using Microsoft.AspNetCore.Mvc;

namespace crm_mvc.Controllers
{
    [Route("Home")]
    public class StartUpPage : Controller
    {
        
        [Route("")]
        [Route("index")]
        [Route("~/")]
        public IActionResult Index()
        {
            
            return RedirectToAction("Index", "LoginUsuarios");
        }
    }
}

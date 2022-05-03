using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace crm.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        [BindProperty]
        public String Usuario { get; set; }
        public int userlogged { get; set; }
        public void OnGet()
        {
            /*   Usuario = HttpContext.Session.GetString("User");
               userlogged = (int)HttpContext.Session.GetInt32("UserLogged");
               if (userlogged == 0)
               {

               }
               else
               {

               }
            */
        }
        public void OnPost()
        {

        }
    }
}
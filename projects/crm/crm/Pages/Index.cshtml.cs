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
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("User") as string))
            {
                //The code
                this.Usuario = HttpContext.Session.GetString("User");
                this.userlogged = (int)HttpContext.Session.GetInt32("UserLogged");
            }
            else
            {
                this.Usuario = "No hay usuario identificado";
                this.userlogged = 0;

            }
          
               /*if (userlogged == 0)
               {

               }
               else
               {

               }
                */
        }

    }
}
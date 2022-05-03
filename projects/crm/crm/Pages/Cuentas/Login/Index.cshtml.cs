
using crm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace crm.Pages.Cuentas.Login
{
    public class IndexModel : PageModel
    {
        
        [BindProperty]
        public Usuarios Usuario { get; set; }
        public void OnGet()
        {
            //Dar un valor a una propiedad de Usuario al cargar la pagina
            this.Usuario = new Usuarios { USUARIO = "Debes itroducir el usuario" };
        }

        public void OnPost()
        {

        }
    }
}

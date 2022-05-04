
using crm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace crm.Pages.Cuentas.Login
{
    public class IndexModel : PageModel
    {
        //Variable local para la conexión
        private readonly crm.Data.CrmContext _context;
        //Establecemos el link a la conexión
        public IndexModel(crm.Data.CrmContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Usuarios Usuario { get; set; }
        public void OnGet()
        {
            //Dar un valor a una propiedad de Usuario al cargar la pagina
            this.Usuario = new Usuarios { USUARIO = "Debes introducir el usuario" };
        }

        public void OnPost()
        {
            try
            {
                var Username = Usuario.USUARIO;
                var Password = Usuario.PASSWORD;
                //¿Como se lee de la base de datos?
                //modo 1
                var query = _context.Usuarios.Where(s => s.USUARIO == Username)
                       .FirstOrDefault<Usuarios>();
                //modo2
                var query1 = from st in _context.Usuarios
                             where st.ID >=1 
                             select st;
                var usuario  = query1.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

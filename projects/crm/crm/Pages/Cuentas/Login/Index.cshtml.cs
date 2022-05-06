
using crm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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
            HttpContext.Session.SetString("mensaje", "");
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                var Username = Usuario.USUARIO;
                var Password = Usuario.PASSWORD;
                //¿Como se lee de la base de datos?

                //Validar sin procedimiento
                //modo 1
                var query = _context.Usuarios.Where(s => s.USUARIO == Username)
                       .FirstOrDefault();
                //¿Encontré al usuario?
                if (!string.IsNullOrEmpty(query.ToString()))
                {
                    //Si
                    //¿Está el usuario activo?
                    if(query.ISACTIVE == 1)
                    {
                        //Si
                        
                        //¿He validado la password?
                        if (Password == query.PASSWORD)
                        {
                            HttpContext.Session.SetString("usuario", Username);
                            HttpContext.Session.SetInt32("UserLogged", 1);
                            HttpContext.Session.SetString("mensaje", "Bienvenido");
                            return RedirectToPage("/Index");
                        }
                        else
                        {
                            HttpContext.Session.SetString("usuario", Username);
                            HttpContext.Session.SetInt32("UserLogged", 0);
                            HttpContext.Session.SetString("mensaje", "Password incorrecta");
                            return Page();
                        }
                        
                    }
                    else
                    {
                        //No
                        HttpContext.Session.SetString("usuario", Username);
                        HttpContext.Session.SetInt32("UserLogged", 0);
                        HttpContext.Session.SetString("mensaje", "Usuario no activo, contactar administrador");
                        return Page();
                    }

                } else
                {
                    //No
                    HttpContext.Session.SetString("usuario", "No Encontrado");
                    HttpContext.Session.SetInt32("UserLogged", 0);
                    HttpContext.Session.SetString("mensaje", "Usuario no encontrado");
                    return Page();
                }

                //Validar con procedimiento
                //string sql = "EXEC Validate_User @Username = {0}, @password  = {1}";
                //var userLogged = _context.Usuarios.FromSqlRaw<Usuarios>(sql, Username, Password);
                //modo2
                //var query1 = from st in _context.Usuarios
                //             where st.ID >=1 
                //             select st;
                //var usuario  = query1.ToList();
            }
            catch (Exception)
            {
                //throw;
                return RedirectToPage("/Error");
            }
        }
    }
}

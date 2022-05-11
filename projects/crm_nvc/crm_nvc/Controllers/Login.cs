using crm_nvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace crm_nvc.Controllers
{
    public class Login : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private Controllers.UsuariosController _UsuariosController;
        //post: Usuarios/login
        [HttpPost]
        public async Task<IActionResult> LoginUser([Bind("ID,USUARIO,PASSWORD,CREATEDDATE,LASTLOGINDATE,ISACTIVE,EMAIL")] Usuarios Usuario)
        {
             
            try
            {
                var Username = Usuario.USUARIO;
                var Password = Usuario.PASSWORD;
                //¿Como se lee de la base de datos?

                //Validar sin procedimiento
                //modo 1

                //¿Encontré al usuario?
                var result = _UsuariosController.DetailsName(Username);
                if (result == null)
                {

                }
                else
                {

                }


            }
            catch (Exception)
            {
                //throw;
                return RedirectToPage("/Error");
            }
        }
    }
}

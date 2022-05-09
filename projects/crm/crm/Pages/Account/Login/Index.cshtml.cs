using crm.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
//using Microsoft.AspNetCore.Http;

namespace crm.Pages.Login
{
    public class LoginModel : PageModel
    {
        //Para no empezar desde 0
        //https://endjin.com/blog/2022/03/adding-authentication-and-authorisation-to-aspnet-core-web-applications
        //Variable local para la conexión
        private readonly crm.Data.CrmContext _context;

        //Establecemos el link a la conexión
        public LoginModel(crm.Data.CrmContext context)
        {
            _context = context;
        }
        /*
         * https://docs.microsoft.com/es-es/aspnet/core/fundamentals/app-state?view=aspnetcore-6.0
         * gestion de sesiones
         */
        [BindProperty]
        public Usuarios Credential { get; set; }
        public void OnGet()
        {
            this.Credential = new Usuarios { USUARIO = "Introduce usuario" };
        }
        //elemento para recibir el evento de postback
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPost()
        {
            //Para ver errores al arrancar post en el modelo
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            //Seguridad comprobamos las credenciales
            if (!ModelState.IsValid)
            {
                HttpContext.Session.SetInt32("UserLogged", 0);
                HttpContext.Session.SetString("User", "");
                return Page();
            }
            //Comprobamos usuario y password
            //_context.Attach(Credential).State = EntityState.Modified;

            try
            {
                var Username = Credential.USUARIO;
                var Password = Credential.PASSWORD;
                Console.WriteLine("validando usuario");
                string sql = "EXEC Validate_User @Username = {0}, @password  = {1}";
                var users = _context.Usuarios.FromSqlRaw(sql, Username, Password).ToList();
                if (users.Count == 1)
                {
                    if (users[0].ID <= 0)
                    {
                        if (users[0].ID == -2)
                        {
                            HttpContext.Session.SetInt32("UserLogged", 0);
                            HttpContext.Session.SetString("User", "");
                            return Page();
                        }
                        else if (users[0].ID == -1)
                        {
                            HttpContext.Session.SetInt32("UserLogged", 0);
                            HttpContext.Session.SetString("User", "");
                            return Page();
                        }
                        else
                        {
                            HttpContext.Session.SetInt32("UserLogged", 0);
                            HttpContext.Session.SetString("User", "");
                            return Page();
                        }
                    }
                    else
                    {
                        //Seting session values
                        //https://www.learnrazorpages.com/razor-pages/session-state
                        HttpContext.Session.SetInt32("UserLogged", 1);
                        HttpContext.Session.SetString("User", Username);


                        //Creating security context
                        /*
                         * https://docs.microsoft.com/es-es/dotnet/api/microsoft.aspnetcore.authorization.iauthorizationservice?view=aspnetcore-6.0
                         */
                        var claims = new List<Claim> {
                           new Claim(ClaimTypes.Name, Username),
                           new Claim(ClaimTypes.Email, Username + "@crm.com")
                        };
                        //Creamos la identidad para asociarle los valores
                        var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                        //Ahora creamos el elemento principal para seguridad qie contiene el
                        //contexto de seguridad
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                        //Preparamos la cookie
                        await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
                        //Fin Creating security context

                        //Si el login es correcto redirigimos al index
                        return RedirectToPage("/Index");
                    }
                    
                }
                else
                {
                    HttpContext.Session.SetInt32("UserLogged", 0);
                    HttpContext.Session.SetString("User", "");
                    return Page();
                }
                
            }
            catch (DbUpdateConcurrencyException)
            {
                return RedirectToPage("/Error");
                

            }
            
        }
    }

}

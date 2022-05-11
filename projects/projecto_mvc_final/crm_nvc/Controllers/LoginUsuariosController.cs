#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using crm_mvc.Data;
using crm_mvc.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace crm_mvc.Controllers
{
    public class LoginUsuariosController : Controller
    {
        private readonly crm_mvc_Context _context;

        public LoginUsuariosController(crm_mvc_Context context)
        {
            _context = context;
        }

        // GET: LoginUsuarios
        public IActionResult Index()
        {
            return View();
        }

        private Controllers.UsuariosController _UsuariosController;

        // POST: LoginUsuarios
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginUsername([Bind("ID,USUARIO,PASSWORD")] LoginUsuario loginUsuario)
        {
            //INicializar el objeto para UsuariosController
            _UsuariosController = new UsuariosController(_context);

            if (ModelState.IsValid)
            {
                var Username = loginUsuario.USUARIO;
                var Password = loginUsuario.PASSWORD;

                //Pedir los datos de usuario para comprobar la password
                //var listarResult = _UsuariosController.DetailsName(Username);
                var result = await _UsuariosController.DetailsNameUsr(Username);
                
                if (result != null)
                {
                    //el usuario y a password vienen en el result[0]
                    //Comprobamos si coincide la password
                    //if(listarResult.Result.GetEnumerator().Current.PASSWORD == Password)
                    if (result.PASSWORD == Password)
                    {
                        //Comprobar si el usuario está activo
                        if (result.ISACTIVE == 1)
                        {
                            //El usuario puede continuar
                            //Añadimos la seguridad a la cookie
                            var claims = new List<Claim>
                            {
                                new Claim(ClaimTypes.Name, Username),
                            };

                            var claimsIdentity = new ClaimsIdentity(
                                claims, CookieAuthenticationDefaults.AuthenticationScheme);

                            var authProperties = new AuthenticationProperties
                            {
                                //AllowRefresh = <bool>,
                                // Refreshing the authentication session should be allowed.

                                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                                // The time at which the authentication ticket expires. A 
                                // value set here overrides the ExpireTimeSpan option of 
                                // CookieAuthenticationOptions set with AddCookie.

                                //IsPersistent = true,
                                // Whether the authentication session is persisted across 
                                // multiple requests. When used with cookies, controls
                                // whether the cookie's lifetime is absolute (matching the
                                // lifetime of the authentication ticket) or session-based.

                                //IssuedUtc = <DateTimeOffset>,
                                // The time at which the authentication ticket was issued.

                                //RedirectUri = <string>
                                // The full path or absolute URI to be used as an http 
                                // redirect response value.
                            };

                            await HttpContext.SignInAsync(
                                CookieAuthenticationDefaults.AuthenticationScheme,
                                new ClaimsPrincipal(claimsIdentity),
                                authProperties);


                            return RedirectToAction("Index", "Customers");

                        }
                        else
                        {
                            //El usuario no esta activo
                            ModelState.AddModelError(string.Empty, "El usuario no está activo, contactar con el administrador.");
                            return RedirectToAction("Index", "LoginUsuarios");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "El usuario no es válido, comprobar usuario/password");
                        return RedirectToAction("Index", "LoginUsuarios");
                    }
                }
                else
                {
                    //El usuario no existe
                    ModelState.AddModelError(string.Empty, "El usuario no es válido, comprobar usuario/password");
                    return RedirectToAction("Index", "LoginUsuarios");

                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error en login contactar con el administrador");
                return RedirectToAction("Index", "LoginUsuarios");
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crm_mvc.Middlewares
{
    public class ControlLoginMiddleware 
    { 
          
        private readonly RequestDelegate _next;
        //Costructor
        public ControlLoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        //Que hacer cuando me llamen?
        public Task Invoke(HttpContext _httpcontext)
        {
            var usuario_logged = -1;
            //Comprobar con la sesion sin he validado usuario y password
            if (_httpcontext.Session.GetInt32("UserLogged").HasValue)
            {
                usuario_logged = (int)_httpcontext.Session.GetInt32("UserLogged");
                //1
                if (usuario_logged == 1)
                {
                    return _next(_httpcontext);
                }
                else if (usuario_logged == 0)
                {
                    //return RedirectToAction("Index", "Home");
                    return null;
                }
                else
                {
                    //return RedirectToAction("Index", "Home");
                    return null;
                }
                

            }
            else
            {
                //So no hay valor estoy en el arranque
                return _next(_httpcontext);
            }
        }
    }
    public static class ControlLoginMiddlewareEtension
    {
        public static IApplicationBuilder UtilizaControlLoginMiddleware(this IApplicationBuilder builder)
        {
            if (builder == null)
            {
                return null;
            }
            else
            {
                return builder.UseMiddleware<ControlLoginMiddleware>();
            }
        }

    }
}
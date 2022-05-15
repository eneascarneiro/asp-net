using System.Diagnostics;

namespace crm_mvc.Middlewares
{
    public class DatosNavegadorMiddleware
    {
        //Objeto para llamar al siquiente elemento del middleware
        private readonly RequestDelegate _next;
        //Constructor
        public DatosNavegadorMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public Task Invoke(HttpContext httpContext)
        {
            var userAgent = httpContext.Request.Headers["User-Agent"].ToString();
            var ipAddress = httpContext.Connection.RemoteIpAddress.ToString();
            var url = httpContext.Request.Path;
            Debug.WriteLine("User Agent: " + userAgent);
            Debug.WriteLine("IP: " + ipAddress);
            Debug.WriteLine("Url: " + url);

            //Mandamos control al siguiente
            return _next(httpContext);
        }
    }

    //Habilitamos que nuestro middleware pueda interrumpir y capturar la peticion
    public static class DatosNavegadorMiddlewareExtensions
    {
        public static IApplicationBuilder UtilizaDatosNavegadorMiddleware(this IApplicationBuilder builder)
        {
            if (builder == null)
            {
                return null;
            }
            else
            {
                return builder.UseMiddleware<DatosNavegadorMiddleware>();
            }
        }
    }
}

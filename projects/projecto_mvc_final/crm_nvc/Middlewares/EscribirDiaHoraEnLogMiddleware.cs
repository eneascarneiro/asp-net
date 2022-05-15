using System.Diagnostics;

namespace crm_mvc.Middlewares
{
    public class EscribirDiaHoraEnLogMiddleware
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;
        //Costructor
        public EscribirDiaHoraEnLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        //Que hacer cuando me llamen?
        public Task Invoke (HttpContext _httpcontext)
        {
            Debug.WriteLine("Date: " + DateTime.Now.ToLongDateString());
            return _next(_httpcontext);
        }
    }
    public static class EscribirDiaHoraEnLogMiddlewareEtension
    {
        public static IApplicationBuilder UtilizaEscribirDiaHoraEnLogMiddleware(this IApplicationBuilder builder)
        {
            if (builder == null)
            {
                return null;
            }
            else
            {
                return builder.UseMiddleware<EscribirDiaHoraEnLogMiddleware>();
            }
        }

    }
}

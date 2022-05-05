using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using crm.Data;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("crmContextConnection");

builder.Services.AddDbContext<crmContext>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<crmUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<crmContext>();;


builder.Services.AddDbContext<CrmContext>(options =>
    options.UseSqlServer(connectionString));;



// Add services to the container.
builder.Services.AddRazorPages();
//A�adimos en manejador de autenticaci�n 
builder.Services.AddAuthentication().AddCookie("MyCookieAuth", options =>
 {
     //Establecemos el nombre se la cookie
     options.Cookie.Name = "MyCookieAuth";
 });
//Fin en manejador de autenticaci�n

//C�digo para gestionar p�ginas con enrutamiento
builder.Services.AddMvc().AddRazorPagesOptions(options =>
{
    options.Conventions.AddPageRoute( "/Account/login","");
});
//Fin c�digo para gestionar p�ginas con enrutamiento

// C�digo para la gesti�n de sesiones
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    //Nombre de la cookie de almacenamiento
    options.Cookie.Name = ".crm.Session";
    //Tiempo para que expire la sesi�n
    options.IdleTimeout = TimeSpan.FromSeconds(100);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Fin C�digo para la gesti�n de sesiones
//A�adimos el contexto de comunicacion a la base de datos
builder.Services.AddDbContext<CrmContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CrmContext") ?? throw new InvalidOperationException("Connection string 'CrmContext' not found.")));
//Fin del manejador de autenticaci�n 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();
// C�digo para la gesti�n de sesiones
app.UseSession();
// Fin C�digo para la gesti�n de sesiones


app.MapRazorPages();

app.Run();

using Aplicacion.AplicacionesCabania;
using Aplicacion.AplicacionesMantenimientos;
using Aplicacion.AplicacionesTipoCabania;
using Aplicacion.AplicacionesUsuario;
using Aplicacion.AplicacionParametros;
using Datos.Entity;
using Datos.Repositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Negocio.InterfacesRepositorio;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.IncludeXmlComments("WebAPI.xml"));

////////////////// JWT ///////////////////////////////////
var claveSecreta = "ZWRpw6fDo28gZW0gY29tcHV0YWRvcmE="; //PUEDE SER OTRA CLAVE, SI ES FUERTE

builder.Services.AddAuthentication(aut =>
{
    aut.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    aut.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(aut =>
{
    aut.RequireHttpsMetadata = false;
    aut.SaveToken = true;
    aut.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(claveSecreta)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
//////////////////// FIN JWT ////////////////////////

//AGREGAR INFORMACIÓN PARA LA INYECCIÓN DE DEPENDENCIAS AUTOMÁTICA:
builder.Services.AddScoped<IRepositorioTipoCabania, RepositorioTipoCabania>();
builder.Services.AddScoped<IRepositorioCabania, RepositorioCabania>();
builder.Services.AddScoped<IRepositorioMantenimiento, RepositorioMantenimiento>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioParametros, RepositorioParametros>();


#region Usuario
builder.Services.AddScoped<ILoginUsuario, LoginUsuario>();
builder.Services.AddScoped<IAltaUsuario, AltaUsuario>();
builder.Services.AddScoped<IValidarSession, ValidarSession>();
#endregion

#region Build Mantenimiento
builder.Services.AddScoped<IDeleteMantenimiento, DeleteMantenimiento>();
builder.Services.AddScoped<IAltaMantenimiento, AltaMantenimiento>();
builder.Services.AddScoped<IListadoMantenimiento, ListadoMantenimiento>();
builder.Services.AddScoped<IDeleteMantenimiento, DeleteMantenimiento>();
builder.Services.AddScoped<IFindByDate, FindByDate>();
builder.Services.AddScoped<IFindByCabania, FindByCabania>();
builder.Services.AddScoped<IFindByValues, FindByValues>();
#endregion


#region Build cabania
builder.Services.AddScoped<IAltaCabania, AltaCabania>();
builder.Services.AddScoped<IListadoCabania, ListadoCabania>();
builder.Services.AddScoped<IFindByIdTipo, FindByIdTipo>();
builder.Services.AddScoped<IFindByIdCabania, FindByIdCabania>();
builder.Services.AddScoped<IFiltroPrecio, FiltroPrecio>();

builder.Services.AddScoped<IBusquedaConFiltros, BusquedaConFiltros>();


#endregion


#region Build TipoCabania
builder.Services.AddScoped<IAltaTipoCabania, AltaTipoCabania>();
builder.Services.AddScoped<IListadoTipoCabania, ListadoTipoCabania>();
builder.Services.AddScoped<IFindByName, FindByName>();
builder.Services.AddScoped<IDeleteTipo, DeleteTipo>();
builder.Services.AddScoped<IUpdateTipo, UpdateTipo>();
builder.Services.AddScoped<IFindCabaniaPorTipo, FindCabaniaPorTipo>();
#endregion

builder.Services.AddScoped<IUpdateParametro, UpdateParametro>();
builder.Services.AddScoped<IObtenerMaxMinDescripcion, ObtenerMaxMin>();

var configurationBuilder = new ConfigurationBuilder();
configurationBuilder.AddJsonFile("appsettings.json", false, true);
var configuration = configurationBuilder.Build();
string strCon = configuration.GetConnectionString("MiConexion");

builder.Services.AddDbContext<LibreriaContext>(options => options.UseSqlServer(strCon));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

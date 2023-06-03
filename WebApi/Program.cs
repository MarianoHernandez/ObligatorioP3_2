using Aplicacion.AplicacionesCabaña;
using Aplicacion.AplicacionesMantenimientos;
using Aplicacion.AplicacionesTipoCabaña;
using Aplicacion.AplicacionesUsuario;
using Aplicacion.AplicacionParametros;
using Datos.Repositorios;
using Negocio.InterfacesRepositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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



#endregion


#region Build cabania
builder.Services.AddScoped<IAltaCabania, AltaCabania>();
builder.Services.AddScoped<IListadoCabania, ListadoCabania>();
builder.Services.AddScoped<IFindById, FindById>();
builder.Services.AddScoped<IFindByIdCabania, FindByIdCabania>();

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

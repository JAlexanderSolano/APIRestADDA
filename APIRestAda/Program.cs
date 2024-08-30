using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();
var configuration = builder.Configuration;


builder.Services.AddRazorPages();
builder.Services.AddCors();
builder.Services.AddTransient<Entities.Interfaces.IRepositoryGuardar, Busniess.Guardar>();
builder.Services.AddTransient<Entities.Interfaces.IRepositoryActualizar, Busniess.Actualizar>();
builder.Services.AddTransient<Entities.Interfaces.IRepositoryEliminar, Busniess.Eliminar>();

//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SwaggerAPIADDA", Version = "v1" });
//    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
//    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
//    c.IncludeXmlComments(xmlPath);
//});

builder.Services.AddControllers();

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

app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();

//app.UseSwagger();

app.UseCors(_cors =>
{
    _cors.AllowAnyOrigin();
    _cors.AllowAnyMethod();
    _cors.AllowAnyHeader();
});

//app.UseSwaggerUI(c =>
//{
//    c.SwaggerEndpoint("/swagger/v1/swagger.json", "APIAdda V1");
//});

var host = configuration["Settings:ConecctionDB"];
if (host != null)
{
    // establecemos la instacia de bd en la capa de negocios para anclarlo a la capa de datos
    // en conexion de bd..
    Busniess.InstanciaConexion conexion = new Busniess.InstanciaConexion();
    conexion.Instancia(host);
}

app.Run();

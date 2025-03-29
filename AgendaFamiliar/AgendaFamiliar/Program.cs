using AgendaFamiliar.Data;
using AgendaFamiliar.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configurar conexión a la base de datos
builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("SupabaseDB")));

// Registrar servicios y controladores
builder.Services.AddControllers();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<AgendarService>();

// Habilitar explorador de endpoints y documentación Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Mi API de Proyecto AgendaFamiliar",
        Version = "v1.0",
        Description = "Documentación de API para proyecto de clase de Programación Móvil"
    });
});

// Agregar configuración de CORS
builder.Services.AddCors();

var app = builder.Build();

// Configuración global de CORS para aceptar solicitudes externas
app.UseCors(builder =>
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());

// Configurar el pipeline de la aplicación
app.UseAuthorization();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
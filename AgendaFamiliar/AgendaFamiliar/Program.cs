using AgendaFamiliar.Data;
using AgendaFamiliar.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configurar conexi�n a la base de datos
builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("SupabaseDB")));

// Registrar servicios y controladores
builder.Services.AddControllers();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<AgendarService>();

// Habilitar explorador de endpoints y documentaci�n Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Mi API de Proyecto AgendaFamiliar",
        Version = "v1.0",
        Description = "Documentaci�n de API para proyecto de clase de Programaci�n M�vil"
    });
});

// Agregar configuraci�n de CORS
builder.Services.AddCors();

var app = builder.Build();

// Configuraci�n global de CORS para aceptar solicitudes externas
app.UseCors(builder =>
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());

// Configurar el pipeline de la aplicaci�n
app.UseAuthorization();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
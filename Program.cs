using Microsoft.OpenApi.Models;
using F1ApiBase.Models;
using F1ApiBase.Services;
using F1ApiBase.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "F1 API Base", 
        Version = "v1",
        Description = "API base para gestión de circuitos y pilotos de Fórmula 1"
    });

    // Incluir comentarios XML para Swagger
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }
});

// Configuración de Inyección de Dependencias (DI)
builder.Services.AddSingleton<ICircuitoService, CircuitoService>();
builder.Services.AddSingleton<IPilotoService, PilotoService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "F1 API Base V1");
        app.UseSwaggerUI(); // Para que Swagger sea la página de inicio
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

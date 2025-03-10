
using DataObjects;
using Microsoft.Extensions.Options;
using Serilog;

var logDirectory = Path.Combine(AppContext.BaseDirectory, "Logs");
var logFilePath = Path.Combine(logDirectory, "log-.txt");

// Asegurar que el directorio de logs existe
if (!Directory.Exists(logDirectory))
{
    Directory.CreateDirectory(logDirectory);
}

// Configurar Serilog para escribir en archivos
Log.Logger = new LoggerConfiguration()
    .WriteTo.File(logFilePath,
                  rollingInterval: RollingInterval.Day, // Un archivo por día
                  retainedFileCountLimit: 30,          // Mantiene 30 días de logs
                  fileSizeLimitBytes: 10_000_000,      // Tamaño máximo por archivo (10MB)
                  rollOnFileSizeLimit: true,
                  outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}")
    .CreateLogger();


var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));

builder.Services.AddSingleton(sp =>
{
    var connectionStrings = sp.GetRequiredService<IOptions<ConnectionStrings>>().Value;
    return connectionStrings;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();

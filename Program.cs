using Cavex.Principal.API.Extensions;
using Cavex.Principal.Core.Contract;
using Cavex.Principal.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;
using NLog;
using NLog.Web;
using System.Reflection;
using System.Threading.RateLimiting;


var logger = LogManager
    .Setup()
    .LoadConfigurationFromFile("nlog.config")
    .GetCurrentClassLogger();

try { 

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();

    builder.Services.AddMemoryCache();
    /*agregamos los elementos de cache y de ratelimit*/
    builder.Services.AddRateLimiter(options =>
    {
        options.AddPolicy("CatalogReadPolicy", httpContext =>
            RateLimitPartition.GetFixedWindowLimiter(
                partitionKey: httpContext.Connection.RemoteIpAddress?.ToString() ?? "anonymous",
                factory: _ => new FixedWindowRateLimiterOptions
                {
                    PermitLimit = 60,
                    Window = TimeSpan.FromMinutes(1),
                    QueueLimit = 0,
                    AutoReplenishment = true
                }));

        options.AddPolicy("CatalogWritePolicy", httpContext =>
            RateLimitPartition.GetFixedWindowLimiter(
                partitionKey: httpContext.Connection.RemoteIpAddress?.ToString() ?? "anonymous",
                factory: _ => new FixedWindowRateLimiterOptions
                {
                    PermitLimit = 20,
                    Window = TimeSpan.FromMinutes(1),
                    QueueLimit = 0,
                    AutoReplenishment = true
                }));
    });


    // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
    //builder.Services.AddOpenApi();

    builder.Services.AddDbContext<CavexContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

    builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    //builder.Services.AddAutoMapper(typeof(Program));
    builder.Services.AddAutoMapper( cf => { }, AppDomain.CurrentDomain.GetAssemblies());
    builder.Services.AddSwaggerGen(options =>
    {
        options.EnableAnnotations();

        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Cavex Principal API",
            Version = "v1",
            Description = "API principal para catalogos y procesos de Cavex.",
            Contact = new OpenApiContact
            {
                Name = "Grupo Cavex",
                Email = "soporte@cavex.com"
            }
        });

        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

        if (File.Exists(xmlPath))
        {
            options.IncludeXmlComments(xmlPath);
        }
    });

    var app = builder.Build();

    app.UseGlobalExceptionMiddleware();

    // Configure the HTTP request pipeline.
    //if (app.Environment.IsDevelopment())
    //{
        //app.MapOpenApi();
        app.UseSwagger();

        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Cavex Principal API v1");
        });
    //}

    app.UseHttpsRedirection();
    app.UseRateLimiter();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch (Exception exception)
{
    logger.Error(exception, "La aplicacion se detuvo por una excepcion no controlada.");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}
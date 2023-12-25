using Microsoft.EntityFrameworkCore;
using R54_M11_Class_01_Work_02.HostedServices;
using R54_M11_Class_01_Work_02.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProductDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("db")));
builder.Services.AddScoped<ApplyMigrationService>();
builder.Services.AddHostedService<MigrationHostedService>();
builder.Services.AddCors(options => {
    options.AddPolicy("EnableCORS",
        builder => {
            builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();

        });
});

builder.Services.AddControllers().AddNewtonsoftJson(
    settings =>
    {
        settings.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
        settings.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
    }
    );
var app = builder.Build();
app.UseStaticFiles();
app.UseCors("EnableCORS");
app.MapControllers();
app.Run();

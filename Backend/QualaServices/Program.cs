using Microsoft.EntityFrameworkCore;
using QualaServices.Interfaces;
using QualaServices.Models;
using QualaServices.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
//Inyection Dbcontext
builder.Services.AddDbContext<QualaDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ApisConnection"),
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                });
});

builder.Services.AddScoped<IMoneda, MonedaServices>();
builder.Services.AddScoped<ISucursal, SucursalServices>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyHeader()
               .AllowAnyMethod();
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

app.UseAuthorization();

app.MapControllers();
app.UseCors("AllowOrigin");

app.Run();

using Izeem.API.Extensions;
using Izeem.API.Middlewares;
using Izeem.DAL.Contexts;
using Izeem.Service.Commons.Helpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

builder.Services.AddDbContext<IzeemDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//AuthSwagger
builder.ConfigureSwaggerAuth();
builder.ConfigureJwtAuth();

//Services
builder.Services.AddCustomServices();
//builder.ConfigureServiceLayer();

var app = builder.Build();

PathHelper.WebRootPath = Path.GetFullPath("wwwroot");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.InitAccessor();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

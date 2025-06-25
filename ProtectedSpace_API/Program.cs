using Bll_Service.Services;
using Core.Mapping;
using Core.Repository;
using Core.Services;
using Dal_Repository_Infrastructor;
using Dal_Repository_Infrastructor.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddScoped<IRepository_Address, Repository_Address>();
builder.Services.AddScoped<IServices_Address, Services_Address>();
builder.Services.AddScoped<IRepository_TypeStructure, Repository_TypeStructure>();
builder.Services.AddScoped<IServices_TypeStructure, Services_TypeStructure>();
builder.Services.AddScoped<IRepository_Opinion, Repository_Opinion>();
builder.Services.AddScoped<IServices_Opinion, Services_Opinion>();

//הזרקת מסד הנתונים
builder.Services.AddDbContext<ProtectedSpace_context>(options =>
options.UseSqlServer("Server=MC-XK1QNMU5BBQD\\SQLExpress;Database=ProtectedSpace;Trusted_Connection=True;TrustServerCertificate=True"));
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ProtectedSpace_API.Middleware.IsraeliIdMiddleware>();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
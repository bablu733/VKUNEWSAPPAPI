using Microsoft.EntityFrameworkCore;
using VKUNEWSAPPAPI.Data.Repository;
using VKUNEWSAPPAPI.Data;
using VKUNEWSAPPAPI.Data.Models;
using VKUNEWSAPPAPI.Data.Repository.Interface;
using VkuNewsApp.Data.Repository;
using VKUNEWSAPPAPI.Service.Interface;
using VKUNEWSAPPAPI.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddDbContext<VKUNEWSAPPAPIDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ??
                         throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));


builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAdminService, AdminService>();

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

app.Run();

using DataAccessLayer.Context;
using DataAccessLayer.interfaces;
using DataAccessLayer.repositries;
using Microsoft.EntityFrameworkCore;
using WebAPIApplication.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// For Entity Framework and SQL Server
builder.Services.AddDbContext<AppDbContext>(op =>
op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();


//adding services
builder.Services.AddScoped<IUserService, UserService>();
//adding repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

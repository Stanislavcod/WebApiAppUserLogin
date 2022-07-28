using Microsoft.EntityFrameworkCore;
using WebApiAppUserLogin.Models;
using WebApiAppUserLogin.Services.Contracts;
using WebApiAppUserLogin.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
builder.Services.AddControllers();

builder.Services.AddTransient<IUserService, UsersService>();
builder.Services.AddTransient<IProfileService, ProfilesService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

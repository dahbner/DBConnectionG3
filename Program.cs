<<<<<<< HEAD
=======

>>>>>>> DBConnectionG3/guest
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<DBConnectionG3.Data.AppDbContext>(opt =>
opt.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

//scoped solo para db externo y singleton para db en memoria
builder.Services.AddScoped<DBConnectionG3.Services.IGuestService, DBConnectionG3.Services.GuestService>();
builder.Services.AddScoped<DBConnectionG3.Repositories.IGuestRepository, DBConnectionG3.Repositories.GuestRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
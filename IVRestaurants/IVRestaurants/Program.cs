using BusinessLogic.Services.Implementations;
using BusinessLogic.Services.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<IVRestaurantsContext>(options =>
   options.UseSqlServer("Server=(localdb)\\MSSqlLocalDb;Database=IVRestaurants;Trusted_Connection=True;"));

builder.Services.AddTransient<IMenuPromoService, MenuPromoService>();
builder.Services.AddTransient<IShoppingCartService, ShoppingCartService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

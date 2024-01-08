using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Order.API.Commands.CheckoutOrder;
using Order.API.Commands.UpdateOrder;
using Order.API.Data;
using Order.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configuracion de EF Core para SQL Server
var connectionString = builder.Configuration.GetConnectionString("OrderDB");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(connectionString));

//Configuracion de Automapper
builder.Services.AddAutoMapper(typeof(Program));

//Inyeccion de dependencia de Order Repository
builder.Services.AddScoped<IOrderAsyncRepository, OrderRepository>();

//Configuracion MediatR
builder.Services.AddMediatR(cfg =>
cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

//Configuracion de los Validators
builder.Services.AddScoped<IValidator<CheckoutOrderCommand>, CheckoutOrderCommandValidator>();
builder.Services.AddScoped<IValidator<UpdateOrderCommand>, UpdateOrderCommandValidator>();

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

using StockControl.Application.Interfaces.Services;
using StockControl.Application.Core.Services;
using StockControl.Business.Interfaces.Managers;
using StockControl.Business.Managers;
using StockControl.DataAccess.Interfaces.Repositories;
using StockControl.DataAccess.EntityFramework.Repositories;
using StockControl.DataAccess.EntityFramework;
using StockControl.Logging.Interfaces.Loggers;
using StockControl.Logging.log4net.Loggers;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

var connectionString = 
    builder.Configuration.GetConnectionString("StockReportDatabase")
        ?? throw new InvalidOperationException("Connection string 'StockReportDatabase' not found.");

// Database Context
builder.Services.AddDbContext<StockControlDbContext>(
    options => options.UseSqlServer(connectionString));

//Setting up Dependency Injection
builder.Services.AddSingleton<IProductMovementService, ProductMovementService>();
builder.Services.AddSingleton<IProductMovementManager, ProductMovementManager>();
builder.Services.AddSingleton<IProductMovementRepository, ProductMovementRepository>();

builder.Services.AddSingleton<IProductManager, ProductManager>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

builder.Services.AddSingleton<IStockReportService, StockReportService>();

builder.Services.AddSingleton<IStockControlLogger, StockControlLogger>();

var allowOrigins = "AllowAll";

builder.Services.AddCors(options =>
 {
     options.AddPolicy(allowOrigins,
         builder => builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader());
 });


// Add services to the container.

builder.Services.AddControllers();
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

app.UseRouting();

app.UseCors(allowOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();

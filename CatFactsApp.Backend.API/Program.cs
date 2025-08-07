
using AutoMapper;
using CatFactsApp.Backend.Business.Services;
using CatFactsApp.Backend.Core;
using CatFactsApp.Backend.Core.Configurations.Mapping;
using CatFactsApp.Backend.Core.IServices;
using CatFactsApp.Backend.Data;
using CatFactsApp.Backend.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;


var builder = WebApplication.CreateBuilder(args);

// Configuración
var configuration = builder.Configuration;

// ----------------------
// Servicios
// ----------------------

// Controladores
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CatFactsApp API",
        Version = "v1"
    });
});

// Configuración de AutoMapper
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MappingProfile>();
});

// DbContext
builder.Services.AddDbContext<AppDbContext>(op => {
    op.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), x =>
    {
        x.UseNetTopologySuite();
    });
});

// CORS (para permitir al frontend acceder al backend)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// IHttpContextAccessor (si lo necesitas más adelante)
builder.Services.AddHttpContextAccessor();

// Servicios 
builder.Services.AddHttpClient();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ICatFactService, CatFactService>();
builder.Services.AddTransient<IGifService, GifService>(); // <== Asegúrate de tener esta clase
builder.Services.AddTransient<ISearchHistoryService, SearchHistoryService>(); // <== Y esta también


// ----------------------
// App
// ----------------------

var app = builder.Build();

// Middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors("AllowAllOrigins"); // Enable CORS for all sources

app.MapControllers();

app.Run();

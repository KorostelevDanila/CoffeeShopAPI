//using CoffeeShopAPI.Models.Data;
using CoffeeShopAPI.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;
using System.Net.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("CoffeeShopYandexCloud");
builder.Services.AddDbContext<CoffeeShopContext>(o => o.UseNpgsql(connectionString));

/*
builder.Services.AddDbContext<CoffeeShopContext>(o => o.UseNpgsql(connectionString, builder =>
{
    builder.RemoteCertificateValidationCallback((s, c, ch, sslPolicyErrors) =>
    {
        if (sslPolicyErrors == SslPolicyErrors.None)
        {
            return true;
        }
        return false;
    });

    builder.ProvideClientCertificatesCallback(clientCerts =>
    {
        var clientCertPath = NpgsqlOptionsExtension.Client
    });
}));
*/

//builder.Services.AddDbContext<CoffeeShopContext>(options => options.UseInMemoryDatabase("coffee_shop"));

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

app.UseAuthorization();

app.MapControllers();

app.Run();
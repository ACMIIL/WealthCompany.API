using Microsoft.OpenApi.Models;
using System.Data.SqlClient;
using WealthCompany.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<WealthCompany.Data.Classes.IConnection>((sp) => new WealthCompany.Data.Classes.AcmCompareConnection(new SqlConnection(builder.Configuration.GetConnectionString("AcmCompare"))));

// configure strongly typed settings object
builder.Services.AddOptions();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WealthCompany.API", Version = "v1" });
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddWealthCompanyServices();

builder.Services.AddMemoryCache();
builder.Services.AddLazyCache();

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

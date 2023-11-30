using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Data.SqlClient;
using System.Text;
using WealthCompany.API.Configuration;
using WealthCompany.Core.Configurations;
using static Dapper.SqlMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddWealthCompanyServices();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<WealthCompany.Data.Classes.IConnection>((sp) => new WealthCompany.Data.Classes.AcmCompareConnection(new SqlConnection(builder.Configuration.GetConnectionString("AcmCompare"))));
builder.Services.AddTransient<WealthCompany.Data.Classes.IConnection>((sp) => new WealthCompany.Data.Classes.TWCConnection(new SqlConnection(builder.Configuration.GetConnectionString("DBUATTWC"))));
//builder.Services.Configure<AppSettings>(Configuration.GetSection("ChhotaNiveshAppSettings"));
builder.Configuration.GetSection("SendSMS").Get<SendSMS>();
//services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

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
builder.Services.AddMemoryCache();
builder.Services.AddLazyCache();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{

    var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Secret"]);

    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(builder => builder
.AllowAnyHeader()
.AllowAnyMethod()
.SetIsOriginAllowed((host) => true)
.AllowCredentials());


app.UseHttpsRedirection();

app.UseAuthorization();
//app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();

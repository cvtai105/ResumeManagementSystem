using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DataAccess.DAOs;
using BusinessLogic;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using Application.Controllers;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

{
    //swagger
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

// Cấu hình dịch vụ logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: MyAllowSpecificOrigins,
        policy  =>
        {
            policy.WithOrigins("http://localhost:3000")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
        }
    );
});


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<NhanVienDAO>();
builder.Services.AddScoped<UngVienDAO>();
builder.Services.AddScoped<DoanhNghiepDAO>();
builder.Services.AddScoped<DangTuyenDAO>();
builder.Services.AddScoped<UuDaiDAO>();
builder.Services.AddScoped<TieuChiTuyenDungDAO>();
builder.Services.AddScoped<HinhThucDangTuyenDAO>();
builder.Services.AddScoped<HinhThucThanhToanDAO>();
builder.Services.AddScoped<ThanhToanDAO>();
builder.Services.AddScoped<DotThanhToanDAO>();
builder.Services.AddScoped<DoanhNghiepBL>();
builder.Services.AddScoped<UngVienBL>();
builder.Services.AddScoped<NhanVienBL>();
builder.Services.AddScoped<TestDAO>();
builder.Services.AddScoped<TestBL>();
builder.Services.AddScoped<HinhThucDangTuyenBL>();
builder.Services.AddScoped<DangTuyenBL>();
builder.Services.AddScoped<TieuChiTuyenDungBL>();
builder.Services.AddScoped<HinhThucThanhToanBL>();


builder.Services.AddControllers();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = config["JwtSettings:Issuer"],
        ValidAudience = config["JwtSettings:Audience"], 
#pragma warning disable CS8604 // Possible null reference argument.
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:SignKey"]))
#pragma warning restore CS8604 // Possible null reference argument.
    };
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            if (context.Request.Cookies.ContainsKey("AuthToken"))
            {
                context.Token = context.Request.Cookies["AuthToken"];
            }
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddAuthorization();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DataAccess.DAOs;
using BusinessLogic;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using Application.Controllers;
using Serilog;
using System.Text.Json.Serialization;
using Microsoft.Extensions.FileProviders;
using Serilog.Events;
using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

//swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Cấu hình dịch vụ logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

var _logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(path: "info-logs.txt", restrictedToMinimumLevel: LogEventLevel.Information)
                .WriteTo.File(path: "error-logs.txt", restrictedToMinimumLevel: LogEventLevel.Error) 
                .CreateLogger();

builder.Logging.AddSerilog(_logger);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
            
            policy.WithOrigins("https://resume-management-system.vercel.app")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
        }
    );
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.MaxDepth = 64; // hoặc giá trị lớn hơn nếu cần thiết
    });

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AzureConnection"));
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

builder.Services.AddScoped<UngTuyenBL>();
builder.Services.AddScoped<UngTuyenDAO>();
builder.Services.AddScoped<HoSoUngTuyenBL>();
builder.Services.AddScoped<HoSoUngTuyenDAO>();

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

// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
// }
// if (!app.Environment.IsDevelopment())
// {
//     app.UseExceptionHandler("/error");
//     app.UseHsts();
// }

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
var staticFilesPath = Path.Combine(builder.Environment.ContentRootPath, "StaticFiles");
// if (!Directory.Exists(staticFilesPath))
// {
//     Directory.CreateDirectory(staticFilesPath);
// }

// var cacheMaxAgeOneWeek = (60 * 60 * 24 * 7).ToString();
// // app.UseStaticFiles(new StaticFileOptions
// // {
// //     FileProvider = new PhysicalFileProvider( 
// //            Path.Combine(builder.Environment.ContentRootPath, "StaticFiles")),
// //     RequestPath = "/static-files",
// //     OnPrepareResponse = ctx =>
// //     {
// //         ctx.Context.Response.Headers.Append(
// //              "Cache-Control", $"public, max-age={cacheMaxAgeOneWeek}");
// //     }
// // });

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


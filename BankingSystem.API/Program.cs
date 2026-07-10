using Scalar.AspNetCore;
using BankingSystem.Infrastructure.DbConfig;
using BankingSystem.API.ExceptionCatcher;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BankingSystem.Application.Config;
var builder = WebApplication.CreateBuilder(args);

//varaibles
string port = builder.Configuration["Port:PORT"] ?? string.Empty;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DbService 
builder.Services.GetSerives(builder.Configuration);

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Authentication:JWT"));

//AuthenticationServices
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = builder.Configuration["Authentication:JWT:Issuer"],
            ValidateIssuer = true,
            ValidAudience = builder.Configuration["Authentication:JWT:Audience"],
            ValidateAudience = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Authentication:JWT:Key"]!)),
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true
        };
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = ctx =>
            {
                _ = ctx.Request.Cookies.TryGetValue("accessToken", out var accessToken);
                if (!string.IsNullOrEmpty(accessToken))
                    ctx.Token = accessToken;
                return Task.CompletedTask;
            }
        };
    });


//exceptionhandler registry
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(static option =>
    {
        option.RouteTemplate = "openapi/{documentName}.json";
    });
    app.MapScalarApiReference();
}

app.UseRouting();
app.UseExceptionHandler(_ => { });
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllers();
});

app.Urls.Add($"https://localhost:{port}");
app.Run();

using Scalar.AspNetCore;
using BankingSystem.Infrastructure.DbConfig;
using BankingSystem.API.ExceptionCatcher;
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

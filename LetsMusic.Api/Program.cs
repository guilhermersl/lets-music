using Microsoft.EntityFrameworkCore;
using LetsMusic.Api.Filters;
using LetsMusic.Application.Config;
using LetsMusic.Data.Config;
using LetsMusic.Data;
using LetsMusic.Api.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomExceptionFilterAtribute>();
});
builder.Services
    .RegisterApplication()
    .RegisterRepository(builder.Configuration.GetConnectionString("LetsMusicDBConn"));

builder.Services.AddEndpointsApiExplorer();

//Configura a Autorização no Swagger
builder.Services.ConfigureSwagger();

builder.Services.AddSwaggerGen();

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

//Essa ordem é importante
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

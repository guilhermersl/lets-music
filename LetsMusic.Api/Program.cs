using Microsoft.EntityFrameworkCore;
using LetsMusic.Api.Filters;
using LetsMusic.Application.Config;
using LetsMusic.Data.Config;
using LetsMusic.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomExceptionFilterAtribute>();
});
builder.Services
    .RegisterApplication()
    .RegisterRepository(builder.Configuration.GetConnectionString("LetsMusicDBConn"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

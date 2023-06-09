using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesProject;
using SalesProject.Context;
using SalesProject.Filters;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<SalesDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ErrorHandlingFilter>();
    options.Filters.Add(new ProducesResponseTypeAttribute(typeof(ProblemDetails), StatusCodes.Status400BadRequest));
    options.Filters.Add(new ProducesResponseTypeAttribute(typeof(ProblemDetails), StatusCodes.Status404NotFound));
    options.Filters.Add(new ProducesResponseTypeAttribute(typeof(ProblemDetails), StatusCodes.Status500InternalServerError));
    options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status200OK));
});

var allowedOrigin = builder.Configuration.GetSection("AllowedOrigin").Value;

var app = builder.Build();

app.UseCors(options => options
    .WithOrigins(allowedOrigin)
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
);

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

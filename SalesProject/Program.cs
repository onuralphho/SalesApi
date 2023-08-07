using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesProject;
using SalesProject.Application.Services;
using SalesProject.Context;
using SalesProject.Core.Interfaces.RepositoryInterfaces;
using SalesProject.Core.Interfaces.RepostoryInterfaces;
using SalesProject.Core.Interfaces.ServiceInterfaces;
using SalesProject.Domain.Repositories;
using SalesProject.Filters;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<SalesDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

#region Services DI
builder.Services.AddScoped<IOrdersService, OrdersService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICampaignService, CampaignService>();
#endregion

#region Repostories DI
builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICampaignRepository, CampaignRepository>();
#endregion



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

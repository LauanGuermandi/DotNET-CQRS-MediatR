using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Api.Application.Common;
using Products.Api.Application.Queries;
using Products.Api.Data.Context;
using Products.Api.Data.Repositories;
using Products.Api.Domain;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProductWriteContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductWrite"));
});
builder.Services.AddDbContext<ProductReadContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductRead"));
});

builder.Services.AddScoped<IProductQueries, ProductQueries>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddMediatR(typeof(Message).GetTypeInfo().Assembly);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

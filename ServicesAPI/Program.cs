using FluentValidation;
using MediatR;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using ServicesAPI.Data;
using ServicesAPI.Models;
using ServicesAPI.Application.Commands;
using System.Reflection;
using ServicesAPI.Application.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ServiceCatalogContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DbConnection"]);
});
builder.Services.AddTransient<IServiceRepository,ServiceRepository>();
builder.Services.AddTransient<IValidator<CreateServiceCommand>, CreateServiceValidator>();
builder.Services.AddTransient<IValidator<UpDateServiceCommand>, UpDateServiceValidator>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();
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

using MediatR;
using FluentValidation.AspNetCore;
using CQRSExample.Application;
using CQRSExample.Application.Validators;
using Etut.Application.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<GetProductsQueryValidator>());

// Register MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetProductsQuery).Assembly));

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CQRSExample.Application.Behaviors.LoggingBehavior<,>));

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline
app.MapControllers();

app.Run();
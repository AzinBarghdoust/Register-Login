using System;
using Application.Commands.User;
using FluentValidation;
using Infrastructure.SqlServer.Context;
using Microsoft.EntityFrameworkCore;
using SignUpSignIn.DTOs.User;

var builder = WebApplication.CreateBuilder(args);

//builder.WebHost.UseSentry();

builder.Services.AddControllers();
builder.Services.AddDbContext<SqlServerContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerContext")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RegisterUserCommand).Assembly));

builder.Services.AddValidatorsFromAssemblyContaining<RegisterUserValidator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

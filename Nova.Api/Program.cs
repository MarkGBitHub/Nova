using Microsoft.EntityFrameworkCore;
using Nova.Api.DataAccess;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.
builder.Services.AddCors();
builder.Services.AddDbContext<ApiContext>(options => options.UseInMemoryDatabase("meolmemory"));
builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(c => c.WithOrigins("http://localhost:3300").AllowAnyHeader().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

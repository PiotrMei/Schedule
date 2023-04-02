using MediatR;
using Microsoft.EntityFrameworkCore;
using ScheduleApp.Entities;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<ScheduleDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("RestaurantDbConnection")));
builder.Services.AddScoped<ScheduleSeeder>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetService<ScheduleSeeder>();
seeder.Seed();

app.MapControllers();

app.Run();

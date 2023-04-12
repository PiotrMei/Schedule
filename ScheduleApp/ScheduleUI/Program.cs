using MediatR;
using Microsoft.EntityFrameworkCore;
using ScheduleCore.Middleware;
using System.Reflection;
using ScheduleCore.Entities;
using ScheduleCore.CommandHandler;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<ScheduleDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("RestaurantDbConnection")));
builder.Services.AddScoped<ScheduleSeeder>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddScoped<ITermsValidator, TermValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetService<ScheduleSeeder>();
seeder.Seed();

var dbContext = scope.ServiceProvider.GetService<ScheduleDbContext>();
await dbContext!.Database.MigrateAsync();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

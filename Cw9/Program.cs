using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Cw9.Data;
using Cw9.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Cw9Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Cw9Context") ?? throw new InvalidOperationException("Connection string 'Cw9Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id}");

app.Run();

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GESTEMRegistration.Data;
using GESTEMRegistration.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//future: change this to sqlite for development and server for production
builder.Services.AddDbContext<GESTEMRegistrationContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("GESTEMRegistrationContext") ?? throw new InvalidOperationException("Connection string 'GESTEMRegistrationContext' not found.")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();


using ContactManagement.Context;
using ContactManagement.Repository;
using Microsoft.EntityFrameworkCore;
using System.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

//var serverVersion = new MySqlServerVersion(new Version(8, 0, 26));
var serverVersion = new MySqlServerVersion(new Version(8, 0, 26));

var connectionString = builder.Configuration.GetConnectionString("MariaDB");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, serverVersion)
);

builder.Services.AddScoped<IContactRepository, ContactRepository>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetService<ApplicationDbContext>();

    if (dbContext != null && dbContext.Database.GetDbConnection().State != ConnectionState.Open)
    {
        dbContext.Database.OpenConnection();

        // Run EnsureCreated() to create the database and any pending migrations
        dbContext.Database.EnsureCreated();
    }
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


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

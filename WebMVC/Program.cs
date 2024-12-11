using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var envName = builder.Environment.EnvironmentName;

IConfigurationRoot configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{envName}.json", optional: true, reloadOnChange: true)
    .Build();

var mssqlConnectionString = configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContextFactory<TrainingDiaryDBContext>(options =>
{
    options
        .UseSqlServer(mssqlConnectionString, x => x.MigrationsAssembly("DataAccessLayer.MSSQL.Migrations"))
        .LogTo(s => System.Diagnostics.Debug.WriteLine(s))
        .EnableSensitiveDataLogging(true)
        .UseLazyLoadingProxies()
        ;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

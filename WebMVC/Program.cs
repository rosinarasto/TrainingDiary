using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var mssqlDbName = "TRAINING-DIARY-DB";
var mssqlConnectionString = $"Server=(localdb)\\mssqllocaldb;Integrated Security=True;MultipleActiveResultSets=True;Database={mssqlDbName};Trusted_Connection=True;";

builder.Services.AddDbContextFactory<TrainingDiaryDBContext>(options =>
{
    options
        .UseSqlServer(
            mssqlConnectionString,
            x => x.MigrationsAssembly("DataAccessLayer.MSSQL.Migrations")
        )
        .LogTo(s => System.Diagnostics.Debug.WriteLine(s))
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

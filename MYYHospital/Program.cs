using Microsoft.EntityFrameworkCore;
using MYYHospital.Db;
using MYYHospital.Repo;
using MYYHospital.Repo.Implement;
using MYYHospital.Repo.Interface;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IDoctor, ImDoctor>();
builder.Services.AddScoped<IPatient, ImPatient>();
builder.Services.AddScoped<IAppointment, ImAppointment>();



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppContexts>(o=>o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();

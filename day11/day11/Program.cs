using day11.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = "Server=CUTDY\\SQLEXPRESS;Database=PhamHoangNam_2301900074;Trusted_Connection=True;TrustServerCertificate=True;";
builder.Services.AddDbContext<PhamHoangNam2301900074Context>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=PhnHome}/{action=PhnIndex}/{id?}");

app.Run();

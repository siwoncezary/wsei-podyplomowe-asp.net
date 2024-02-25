using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Z2.Data;
using Z2.Models;

namespace Z2;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        //var connectionString = builder.Configuration.GetConnectionString("AppDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AppDbContextConnection' not found.");

        // Add services to the container.
        builder.Services.AddRazorPages();       // dodać
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<AppDbContext>();
        
        builder.Services.AddDefaultIdentity<IdentityUser>(options =>        // dodać
        {
            options.SignIn.RequireConfirmedAccount = true;
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 6;
        })
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<AppDbContext>();
        
        // builder.Services.AddDbContext<AppDbContext>(options =>
        // {
        //     options.UseSqlite(builder.Configuration["Data:Connection"]);
        // });
        builder.Services.AddTransient<IBookService, EFBookService>();

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
        app.MapRazorPages();               
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
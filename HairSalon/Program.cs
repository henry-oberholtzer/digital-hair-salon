using Microsoft.EntityFrameworkCore;
using HairSalon.Utilities;
using HairSalon.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(option =>
{
    option.ConstraintMap["slugify"] = typeof(SlugifyParameterTransformer);
});

builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<HairSalonContext>(
    dbContextOptions => dbContextOptions.UseMySql(
        builder.Configuration["ConnectionStrings:DefaultConnection"],
        ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"]
        )
    )
);

WebApplication app = builder.Build();


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "AdminAreaRoute",
        areaName: "Admin",
        pattern: "admin/{controller:slugify=Dashboard}/{action:slugify=Index}/{id:slugify?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller:slugify}/{action:slugify}/{id:slugify?}",
        defaults: new { controller = "Home", action = "Index" });
});

app.Run();


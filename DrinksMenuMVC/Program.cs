using DrinksMenuMVC.Data;
using DrinksMenuMVC.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using DrinksMenuMVC.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// DbContext configuration
builder.Services.AddDbContext<AccountsDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AccountsDbContextConnection")));

builder.Services.AddDefaultIdentity<AccountUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AccountsDbContext>();

// Services configuration
builder.Services.AddScoped<IDrinksService, DrinksService>();
builder.Services.AddScoped<IIngredientsService, IngredientsService>();

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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Seed database
/*AppDbInitializer.Seed(app);*/

app.MapRazorPages();

app.Run();

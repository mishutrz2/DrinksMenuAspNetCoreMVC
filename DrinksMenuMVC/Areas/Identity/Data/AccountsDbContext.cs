using DrinksMenuMVC.Areas.Identity.Data;
using DrinksMenuMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace DrinksMenuMVC.Areas.Identity.Data;

public class AccountsDbContext : IdentityDbContext<AccountUser>
{
    public AccountsDbContext(DbContextOptions<AccountsDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // many-to-many relationship between Drink and Ingredient
        builder.Entity<DrinkIngredient>().HasKey(di => new
        {
            di.DrinkId,
            di.IngredientId
        });

        builder.Entity<DrinkIngredient>().HasOne(d => d.Drink).WithMany(di => di.DrinkIngredients).HasForeignKey(d => d.DrinkId);
        builder.Entity<DrinkIngredient>().HasOne(i => i.Ingredient).WithMany(di => di.DrinkIngredients).HasForeignKey(i => i.IngredientId);

        // many-to-many relationship between User and Ingredient
        builder.Entity<UserIngredient>().HasKey(ui => new
        {
            ui.AccountUserId,
            ui.IngredientId
        });

        builder.Entity<UserIngredient>().HasOne(u => u.AccountUser).WithMany(ui => ui.UserIngredients).HasForeignKey(u => u.AccountUserId);
        builder.Entity<UserIngredient>().HasOne(i => i.Ingredient).WithMany(ui => ui.UserIngredients).HasForeignKey(i => i.IngredientId);

        // many-to-many relationship between User and Drink
        builder.Entity<UserDrink>().HasKey(ud => new
        {
            ud.AccountUserId,
            ud.DrinkId
        });

        builder.Entity<UserDrink>().HasOne(u => u.AccountUser).WithMany(ud => ud.UserDrinks).HasForeignKey(u => u.AccountUserId);
        builder.Entity<UserDrink>().HasOne(d => d.Drink).WithMany(ud => ud.UserDrinks).HasForeignKey(d => d.DrinkId);

        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }

    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Drink> Drinks { get; set; }
    public DbSet<DrinkIngredient> DrinkIngredients { get; set; }
    public DbSet<UserIngredient> UserIngredients { get; set; }
    public DbSet<UserDrink> UserDrinks { get; set; }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<AccountUser>
{
    public void Configure(EntityTypeBuilder<AccountUser> builder)
    {
        /*builder.Property(u => u.FirstName).HasMaxLength(255);
        builder.Property(u => u.LastName).HasMaxLength(255);
        builder.Property(u => u.DisplayName).HasMaxLength(255);*/
    }
}
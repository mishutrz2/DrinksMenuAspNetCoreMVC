using DrinksMenuMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace DrinksMenuMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // many-to-many relationship between Drink and Ingredient
            modelBuilder.Entity<DrinkIngredient>().HasKey(di => new
            {
                di.DrinkId,
                di.IngredientId
            });

            modelBuilder.Entity<DrinkIngredient>().HasOne(d => d.Drink).WithMany(di => di.DrinkIngredients).HasForeignKey(d => d.DrinkId);
            modelBuilder.Entity<DrinkIngredient>().HasOne(i => i.Ingredient).WithMany(di => di.DrinkIngredients).HasForeignKey(i => i.IngredientId);

            // many-to-many relationship between User and Ingredient
            modelBuilder.Entity<UserIngredient>().HasKey(ui => new
            {
                ui.UserId,
                ui.IngredientId
            });

            modelBuilder.Entity<UserIngredient>().HasOne(u => u.User).WithMany(ui => ui.UserIngredients).HasForeignKey(u => u.UserId);
            modelBuilder.Entity<UserIngredient>().HasOne(i => i.Ingredient).WithMany(ui => ui.UserIngredients).HasForeignKey(i => i.IngredientId);

            // many-to-many relationship between User and Drink
            modelBuilder.Entity<UserDrink>().HasKey(ud => new
            {
                ud.UserId,
                ud.DrinkId
            });

            modelBuilder.Entity<UserDrink>().HasOne(u => u.User).WithMany(ud => ud.UserDrinks).HasForeignKey(u => u.UserId);
            modelBuilder.Entity<UserDrink>().HasOne(d => d.Drink).WithMany(ud => ud.UserDrinks).HasForeignKey(d => d.DrinkId);

            // call base class method
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users{ get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<DrinkIngredient> DrinkIngredients { get; set; }
        public DbSet<UserIngredient> UserIngredients { get; set; }
        public DbSet<UserDrink> UserDrinks { get; set; }
    }
}

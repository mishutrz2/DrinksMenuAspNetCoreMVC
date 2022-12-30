﻿// <auto-generated />
using DrinksMenuMVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DrinksMenuMVC.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DrinksMenuMVC.Models.Drink", b =>
                {
                    b.Property<int>("DrinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DrinkId"));

                    b.Property<int>("CurrentStatus")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DrinkImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DrinkName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeOfDrink")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("DrinkId");

                    b.HasIndex("UserId");

                    b.ToTable("Drinks");
                });

            modelBuilder.Entity("DrinksMenuMVC.Models.DrinkIngredient", b =>
                {
                    b.Property<int>("DrinkId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("IngredientId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<string>("Amount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DrinkId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("DrinkIngredients");
                });

            modelBuilder.Entity("DrinksMenuMVC.Models.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IngredientId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasAlcohol")
                        .HasColumnType("bit");

                    b.Property<string>("IngredientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IngredientId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("DrinksMenuMVC.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DrinksMenuMVC.Models.UserDrink", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("DrinkId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("UserId", "DrinkId");

                    b.HasIndex("DrinkId");

                    b.ToTable("UserDrinks");
                });

            modelBuilder.Entity("DrinksMenuMVC.Models.UserIngredient", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("IngredientId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.HasKey("UserId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("UserIngredients");
                });

            modelBuilder.Entity("DrinksMenuMVC.Models.Drink", b =>
                {
                    b.HasOne("DrinksMenuMVC.Models.User", "User")
                        .WithMany("PostedDrinks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DrinksMenuMVC.Models.DrinkIngredient", b =>
                {
                    b.HasOne("DrinksMenuMVC.Models.Drink", "Drink")
                        .WithMany("DrinkIngredients")
                        .HasForeignKey("DrinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DrinksMenuMVC.Models.Ingredient", "Ingredient")
                        .WithMany("DrinkIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drink");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("DrinksMenuMVC.Models.UserDrink", b =>
                {
                    b.HasOne("DrinksMenuMVC.Models.Drink", "Drink")
                        .WithMany("UserDrinks")
                        .HasForeignKey("DrinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DrinksMenuMVC.Models.User", "User")
                        .WithMany("UserDrinks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drink");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DrinksMenuMVC.Models.UserIngredient", b =>
                {
                    b.HasOne("DrinksMenuMVC.Models.Ingredient", "Ingredient")
                        .WithMany("UserIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DrinksMenuMVC.Models.User", "User")
                        .WithMany("UserIngredients")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DrinksMenuMVC.Models.Drink", b =>
                {
                    b.Navigation("DrinkIngredients");

                    b.Navigation("UserDrinks");
                });

            modelBuilder.Entity("DrinksMenuMVC.Models.Ingredient", b =>
                {
                    b.Navigation("DrinkIngredients");

                    b.Navigation("UserIngredients");
                });

            modelBuilder.Entity("DrinksMenuMVC.Models.User", b =>
                {
                    b.Navigation("PostedDrinks");

                    b.Navigation("UserDrinks");

                    b.Navigation("UserIngredients");
                });
#pragma warning restore 612, 618
        }
    }
}

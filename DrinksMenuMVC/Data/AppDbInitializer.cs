using DrinksMenuMVC.Areas.Identity.Data;
using DrinksMenuMVC.Data.Services;
using DrinksMenuMVC.Models;

namespace DrinksMenuMVC.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AccountsDbContext>();

                context.Database.EnsureCreated();

                string varX = "71e8b053-c79b-414d-b786-f5dd41b1d510";

                // add Ingredients
                if (!context.Ingredients.Any())
                {
                    context.Ingredients.AddRange(new List<Ingredient>()
                    {
                        new Ingredient()
                        {
                            IngredientName = "Vodka",
                            Description = "Spirit drink, no taste, no smell, pretty strong.",
                            HasAlcohol = true,
                        },
                        new Ingredient()
                        {
                            IngredientName = "Tequila",
                            Description = "Spirit drink, strong taste, strong aroma.",
                            HasAlcohol = true,
                        },
                        new Ingredient()
                        {
                            IngredientName = "Triple Sec",
                            Description = "Spirit drink, orange taste, pretty strong.",
                            HasAlcohol = true,
                        },
                        new Ingredient()
                        {
                            IngredientName = "Ginger Beer",
                            Description = "Low alcohol beer drink, spicy taste.",
                            HasAlcohol = true,
                        },
                        new Ingredient()
                        {
                            IngredientName = "Orange Juice",
                            Description = "Fruit juice, made from oranges, used in a lot of drinks, acidic.",
                            HasAlcohol = false,
                        },
                        new Ingredient()
                        {
                            IngredientName = "Lime juice",
                            Description = "Acidic fruit juice, used in a lot of drinks, strong aroma.",
                            HasAlcohol = false,
                        }
                    });
                    context.SaveChanges();
                }

                // add Drinks
                if (!context.Drinks.Any())
                {
                    context.Drinks.AddRange(new List<Drink>()
                    {
                        new Drink()
                        {
                            DrinkName = "Margarita",
                            TypeOfDrink = Enums.DrinkType.Cocktail,
                            Description = "Fresh drink, perfect for summer, but also good for getting warm during the winter.",
                            DrinkImageUrl = "https://www.acouplecooks.com/wp-content/uploads/2020/03/Margarita-026.jpg",
                            CurrentStatus = Enums.DrinkStatus.Approved,
                            AccountUserId = varX
                        },
                        new Drink()
                        {
                            DrinkName = "Kamikaze",
                            TypeOfDrink = Enums.DrinkType.Shot,
                            Description = "Shot with vodka and triple sec, fresh and strong.",
                            DrinkImageUrl = "http://shake-that.com/wp-content/uploads/2015/07/Kamikaze-shot1.jpg",
                            CurrentStatus = Enums.DrinkStatus.Approved,
                            AccountUserId = varX
                        },
                        new Drink()
                        {
                            DrinkName = "Moscow Mule",
                            TypeOfDrink = Enums.DrinkType.Cocktail,
                            Description = "Fresh and minty drink, perfect for any time of the day.",
                            DrinkImageUrl = "https://ourbestbites.com/wp-content/uploads/2017/07/Virgin-Moscow-Mule-5-sq.jpg",
                            CurrentStatus = Enums.DrinkStatus.Pending,
                            AccountUserId = varX
                        },
                        new Drink()
                        {
                            DrinkName = "Black Russian",
                            TypeOfDrink = Enums.DrinkType.Cocktail,
                            Description = "Strong drink with coffee taste.",
                            DrinkImageUrl = "https://static.fanpage.it/wp-content/uploads/sites/22/2021/07/black-russian.jpeg",
                            CurrentStatus = Enums.DrinkStatus.Rejected,
                            AccountUserId = varX
                        }
                    });
                    context.SaveChanges();
                }

                // add relationship Users-Ingredients
                if (!context.UserIngredients.Any())
                {
                    context.UserIngredients.AddRange(new List<UserIngredient>()
                    {
                        // for user with id 1
                        new UserIngredient()
                        {
                            AccountUserId = varX,
                            IngredientId = 1,
                            IsAvailable = true
                        },
                        new UserIngredient()
                        {
                            AccountUserId = varX,
                            IngredientId = 2,
                            IsAvailable = true
                        },
                        new UserIngredient()
                        {
                            AccountUserId = varX,
                            IngredientId = 3,
                            IsAvailable = true
                        },
                        new UserIngredient()
                        {
                            AccountUserId = varX,
                            IngredientId = 4,
                            IsAvailable = true
                        },
                        new UserIngredient()
                        {
                            AccountUserId = varX,
                            IngredientId = 5,
                            IsAvailable = false
                        },
                        new UserIngredient()
                        {
                            AccountUserId = varX,
                            IngredientId = 6,
                            IsAvailable = true
                        },
                    });
                    context.SaveChanges();
                }

                // add relationship Drinks-Ingredients
                if (!context.DrinkIngredients.Any())
                {
                    context.DrinkIngredients.AddRange(new List<DrinkIngredient>()
                    {
                        // ingredients for drink with id 1
                        new DrinkIngredient()
                        {
                            DrinkId = 1,
                            IngredientId = 2,
                            Amount = "30 ml",
                        },
                        new DrinkIngredient()
                        {
                            DrinkId = 1,
                            IngredientId = 3,
                            Amount = "15 ml",
                        },
                        new DrinkIngredient()
                        {
                            DrinkId = 1,
                            IngredientId = 6,
                            Amount = "15 ml",
                        },

                        // ingredients for drink with id 2
                        new DrinkIngredient()
                        {
                            DrinkId = 2,
                            IngredientId = 1,
                            Amount = "30 ml",
                        },
                        new DrinkIngredient()
                        {
                            DrinkId = 2,
                            IngredientId = 3,
                            Amount = "15 ml",
                        },
                        new DrinkIngredient()
                        {
                            DrinkId = 2,
                            IngredientId = 6,
                            Amount = "15 ml",
                        },
                        
                        // ingredients for drink with id 3
                        new DrinkIngredient()
                        {
                            DrinkId = 3,
                            IngredientId = 1,
                            Amount = "30 ml",
                        },
                        new DrinkIngredient()
                        {
                            DrinkId = 3,
                            IngredientId = 4,
                            Amount = "90 ml",
                        },
                        new DrinkIngredient()
                        {
                            DrinkId = 3,
                            IngredientId = 6,
                            Amount = "20 ml",
                        },
                        
                        // ingredients for drink with id 4
                        new DrinkIngredient()
                        {
                            DrinkId = 4,
                            IngredientId = 1,
                            Amount = "30 ml",
                        },
                        new DrinkIngredient()
                        {
                            DrinkId = 4,
                            IngredientId = 5,
                            Amount = "15 ml",
                        },
                        new DrinkIngredient()
                        {
                            DrinkId = 4,
                            IngredientId = 6,
                            Amount = "15 ml",
                        }
                    });
                    context.SaveChanges();
                }

                // add relationship Users-Drinks
                if (!context.UserDrinks.Any())
                {
                    context.UserDrinks.AddRange(new List<UserDrink>()
                    {
                        new UserDrink()
                        {
                            AccountUserId = varX,
                            DrinkId = 1,
                        },
                        new UserDrink()
                        {
                            AccountUserId = varX,
                            DrinkId = 2,
                        },
                    });
                    context.SaveChanges();
                }

            }
        }

        // used after adding new AccountUser / edit MyIngredients list
        /*public static void SeedUI(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AccountsDbContext>();

                context.Database.EnsureCreated();

                // AccountUser id
                string varX = "71e8b053-c79b-414d-b786-f5dd41b1d510";


                // add relationship Users-Ingredients
                if (!context.UserIngredients.Any())
                {
                    List<UserIngredient> myList = new();
                    foreach(Ingredient item in IngredientsService)
                    {

                    }
                    context.UserIngredients.AddRange(new List<UserIngredient>()
                    {
                        // for user with id 1
                        new UserIngredient()
                        {
                            AccountUserId = varX,
                            IngredientId = 1,
                            IsAvailable = true
                        },
                        new UserIngredient()
                        {
                            AccountUserId = varX,
                            IngredientId = 2,
                            IsAvailable = true
                        },
                        new UserIngredient()
                        {
                            AccountUserId = varX,
                            IngredientId = 3,
                            IsAvailable = true
                        },
                        new UserIngredient()
                        {
                            AccountUserId = varX,
                            IngredientId = 4,
                            IsAvailable = true
                        },
                        new UserIngredient()
                        {
                            AccountUserId = varX,
                            IngredientId = 5,
                            IsAvailable = false
                        },
                        new UserIngredient()
                        {
                            AccountUserId = varX,
                            IngredientId = 6,
                            IsAvailable = true
                        },
                    });
                    context.SaveChanges();
                }
               
            }
        }*/
    }
}

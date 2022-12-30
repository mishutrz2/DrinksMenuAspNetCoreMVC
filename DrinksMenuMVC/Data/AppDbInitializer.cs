using DrinksMenuMVC.Models;

namespace DrinksMenuMVC.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                // add Users
                if (!context.Users.Any())
                {
                    context.Users.AddRange(new List<User>()
                    {
                        new User()
                        {
                            FullName = "Brisan Mircea",
                            Email = "mishutrz2@yahoo.com",
                            Password = "parola123",
                            DisplayName = "mishutrz2",
                            Country = "Romania",
                            Role = Enums.UserRole.Admin
                        },
                        new User()
                        {
                            FullName = "Stan George",
                            Email = "sroger@yahoo.com",
                            Password = "parola123",
                            DisplayName = "georgesss",
                            Country = "Romania",
                            Role = Enums.UserRole.Moderator
                        },
                        new User()
                        {
                            FullName = "Mirel Florin",
                            Email = "florel@yahoo.com",
                            Password = "parola123",
                            DisplayName = "milflor",
                            Country = "UK",
                            Role = Enums.UserRole.Contributor
                        }
                    });
                    context.SaveChanges();
                }

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
                            UserId = 1
                        },
                        new Drink()
                        {
                            DrinkName = "Kamikaze",
                            TypeOfDrink = Enums.DrinkType.Shot,
                            Description = "Shot with vodka and triple sec, fresh and strong.",
                            DrinkImageUrl = "http://shake-that.com/wp-content/uploads/2015/07/Kamikaze-shot1.jpg",
                            CurrentStatus = Enums.DrinkStatus.Approved,
                            UserId = 1
                        },
                        new Drink()
                        {
                            DrinkName = "Moscow Mule",
                            TypeOfDrink = Enums.DrinkType.Cocktail,
                            Description = "Fresh and minty drink, perfect for any time of the day.",
                            DrinkImageUrl = "https://www.acouplecooks.com/wp-content/uploads/2019/06/Moscow-Mule-062.jpg",
                            CurrentStatus = Enums.DrinkStatus.Pending,
                            UserId = 2
                        },
                        new Drink()
                        {
                            DrinkName = "Black Russian",
                            TypeOfDrink = Enums.DrinkType.Cocktail,
                            Description = "Strong drink with coffee taste.",
                            DrinkImageUrl = "https://static.fanpage.it/wp-content/uploads/sites/22/2021/07/black-russian.jpeg",
                            CurrentStatus = Enums.DrinkStatus.Rejected,
                            UserId = 3
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
                            UserId = 1,
                            IngredientId = 1,
                            IsAvailable = true
                        },
                        new UserIngredient()
                        {
                            UserId = 1,
                            IngredientId = 2,
                            IsAvailable = true
                        },
                        new UserIngredient()
                        {
                            UserId = 1,
                            IngredientId = 3,
                            IsAvailable = true
                        },
                        new UserIngredient()
                        {
                            UserId = 1,
                            IngredientId = 4,
                            IsAvailable = true
                        },
                        new UserIngredient()
                        {
                            UserId = 1,
                            IngredientId = 5,
                            IsAvailable = false
                        },
                        new UserIngredient()
                        {
                            UserId = 1,
                            IngredientId = 6,
                            IsAvailable = true
                        },

                        // for user with id 2
                        new UserIngredient()
                        {
                            UserId = 2,
                            IngredientId = 1,
                            IsAvailable = true
                        },
                        new UserIngredient()
                        {
                            UserId = 2,
                            IngredientId = 2,
                            IsAvailable = true
                        },
                        new UserIngredient()
                        {
                            UserId = 2,
                            IngredientId = 3,
                            IsAvailable = false
                        },
                        new UserIngredient()
                        {
                            UserId = 2,
                            IngredientId = 4,
                            IsAvailable = true
                        },
                        new UserIngredient()
                        {
                            UserId = 2,
                            IngredientId = 5,
                            IsAvailable = true
                        },
                        new UserIngredient()
                        {
                            UserId = 2,
                            IngredientId = 6,
                            IsAvailable = true
                        },

                        // for user with id 3
                        new UserIngredient()
                        {
                            UserId = 3,
                            IngredientId = 1,
                            IsAvailable = true
                        },
                        new UserIngredient()
                        {
                            UserId = 3,
                            IngredientId = 2,
                            IsAvailable = false
                        },
                        new UserIngredient()
                        {
                            UserId = 3,
                            IngredientId = 3,
                            IsAvailable = false
                        },
                        new UserIngredient()
                        {
                            UserId = 3,
                            IngredientId = 4,
                            IsAvailable = true
                        },
                        new UserIngredient()
                        {
                            UserId = 3,
                            IngredientId = 5,
                            IsAvailable = false
                        },
                        new UserIngredient()
                        {
                            UserId = 3,
                            IngredientId = 6,
                            IsAvailable = false
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
                            UserId = 1,
                            DrinkId = 1,
                        },
                        new UserDrink()
                        {
                            UserId = 1,
                            DrinkId = 2,
                        },
                        new UserDrink()
                        {
                            UserId = 2,
                            DrinkId = 2,
                        },
                        new UserDrink()
                        {
                            UserId = 3,
                            DrinkId = 1,
                        },
                    });
                    context.SaveChanges();
                }

            }
        }
    }
}

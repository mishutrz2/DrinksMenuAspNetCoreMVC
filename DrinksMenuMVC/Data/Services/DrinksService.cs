using DrinksMenuMVC.Areas.Identity.Data;
using DrinksMenuMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace DrinksMenuMVC.Data.Services
{
    public class DrinksService : IDrinksService
    {
        private readonly AccountsDbContext _context;

        public DrinksService(AccountsDbContext context)
        {
            _context = context;
        }

        public void Add(Drink drink)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Drink>> GetAll()
        {
            var result = await _context.Drinks.Include(d => d.DrinkIngredients).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Drink>> GetAllAvailableCards(string userId)
        {
            // get the drink available for user with UserId = userId
            var availableDrinks = await _context.Drinks
                .Include(u => u.AccountUser)
                .Include(d => d.DrinkIngredients)
                .ThenInclude(di => di.Ingredient)
                .Where(d => d.DrinkIngredients.All(di => _context.UserIngredients
                    .Any(ui => ui.AccountUserId == userId && ui.IngredientId == di.IngredientId && ui.IsAvailable)))
                .ToListAsync();


            /*var result = await _context.Drinks.Include(d => d.User).ThenInclude(ui => ui.UserIngredients).Include(d => d.DrinkIngredients).ThenInclude(i => i.Ingredient).ToListAsync();*/

            return availableDrinks;
        }

        public async Task<IEnumerable<Drink>> GetAllUnavailableCards(string userId)
        {
            // get the drink available for user with UserId = userId
            var unavailableDrinks = await _context.Drinks
                .Include(u => u.AccountUser)
                .Include(d => d.DrinkIngredients)
                .ThenInclude(di => di.Ingredient)
                .Where(d => d.DrinkIngredients.Any(di => !_context.UserIngredients
                    .Any(ui => ui.AccountUserId == userId && ui.IngredientId == di.IngredientId && ui.IsAvailable)))
                .ToListAsync();

            return unavailableDrinks;
        }

        public Drink GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Drink Update(int id, Drink newDrink)
        {
            throw new NotImplementedException();
        }

        public async Task AddDrink(Drink myDrink, string userId)
        {
            Drink finalDrink = myDrink;
            finalDrink.AccountUserId = userId;

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Drinks.Add(finalDrink);
                    _context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }

            
        }

        public async Task AddDrinkIngredients(string drinkName, IEnumerable<int> ingredientsIds)
        {
            int drinkId = _context.Drinks.Where(e => e.DrinkName == drinkName).FirstOrDefault().DrinkId;

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    foreach(var id in ingredientsIds)
                    {
                        _context.DrinkIngredients.Add(new DrinkIngredient()
                        {
                            DrinkId= drinkId,
                            IngredientId = id,
                            Amount = "not yet implemented"
                        });
                    }
                    _context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }

    }
}

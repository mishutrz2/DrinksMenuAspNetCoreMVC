using DrinksMenuMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace DrinksMenuMVC.Data.Services
{
    public class DrinksService : IDrinksService
    {
        private readonly AppDbContext _context;

        public DrinksService(AppDbContext context)
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

        public async Task<IEnumerable<Drink>> GetAllCards()
        {
            // Get drinks that are available for a certain user
            // set the UserId to 2; will take care of which user is logged in later
            int userId = 2;

            // get the drink available for user with UserId = userId
            var availableDrinks = await _context.Drinks
                .Include(d => d.DrinkIngredients)
                .ThenInclude(di => di.Ingredient)
                .Where(d => d.DrinkIngredients.All(di => _context.UserIngredients
                    .Any(ui => ui.UserId == userId && ui.IngredientId == di.IngredientId && ui.IsAvailable)))
                .ToListAsync();


            /*var result = await _context.Drinks.Include(d => d.User).Include(d => d.DrinkIngredients).ThenInclude(i => i.Ingredient).ToListAsync();
*/
            return availableDrinks;
        }

        public Drink GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Drink Update(int id, Drink newDrink)
        {
            throw new NotImplementedException();
        }
    }
}

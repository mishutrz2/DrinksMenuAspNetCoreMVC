using DrinksMenuMVC.Areas.Identity.Data;
using DrinksMenuMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace DrinksMenuMVC.Data.Services
{
    public class IngredientsService : IIngredientsService
    {
        private readonly AccountsDbContext _context;
        public IngredientsService(AccountsDbContext context)
        {
            _context = context;
        }

        public Ingredient GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Ingredient>> GetAll()
        {
            return await _context.Ingredients.Include(i => i.UserIngredients).ToListAsync();
        }

        public async Task<IEnumerable<Ingredient>> GetAvailableAll()
        {
            return await _context.Ingredients.Include(i => i.UserIngredients).ToListAsync();
        }

        public async Task<IDictionary<int,bool>> GetAvailabilities(string userId)
        {
            var result = new Dictionary<int,bool>();
            /*result.Add(1, true);
            result.Add(2, true);
            result.Add(3, false);
            result.Add(4, false);
            result.Add(5, true);
            result.Add(6, true);*/
            var tempVar = await _context.Ingredients
            .Include(i => i.UserIngredients)
            .ThenInclude(ui => ui.AccountUser)
            .ToListAsync();

            var ingredientsPairs = await _context.Ingredients
            .Include(i => i.UserIngredients)
            .ThenInclude(ui => ui.AccountUser)
            .Where(i => i.UserIngredients.Any(ui => ui.AccountUserId == userId))
            .Select(i => new
            {
                IngredientId = i.IngredientId,
                IsAvailable = i.UserIngredients.First(ui => ui.AccountUserId == userId).IsAvailable
            })
            .ToListAsync();

            foreach (var item in ingredientsPairs)
            {
                result.Add(item.IngredientId, item.IsAvailable);
            }

            return result;
        }

    }
}

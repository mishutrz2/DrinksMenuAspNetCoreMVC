using DrinksMenuMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace DrinksMenuMVC.Data.Services
{
    public class IngredientsService : IIngredientsService
    {
        private readonly AppDbContext _context;
        public IngredientsService(AppDbContext context)
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

        public async Task<IDictionary<int,bool>> GetAvailabilities(int userId)
        {
            var result = new Dictionary<int,bool>();
            /* result.Add(1, true);
            result.Add(2, true);
            result.Add(3, false);
            result.Add(4, false);
            result.Add(5, true);
            result.Add(6, true); */

            var ingredientsPairs = await _context.Ingredients
            .Include(i => i.UserIngredients)
            .ThenInclude(ui => ui.User)
            .Where(i => i.UserIngredients.Any(ui => ui.UserId == userId))
            .Select(i => new
            {
                IngredientId = i.IngredientId,
                IsAvailable = i.UserIngredients.First(ui => ui.UserId == userId).IsAvailable
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

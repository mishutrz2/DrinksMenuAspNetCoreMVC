using DrinksMenuMVC.Areas.Identity.Data;
using DrinksMenuMVC.Models;
using Microsoft.AspNetCore.Identity;
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

    }
}

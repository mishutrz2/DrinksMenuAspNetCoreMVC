/*using DrinksMenuMVC.Areas.Identity.Data;
using DrinksMenuMVC.Models;

namespace DrinksMenuMVC.Data.Services
{
    public class UserIngredientService : IUserIngredientService
    {
        private readonly AccountsDbContext _context;

        public UserIngredientService(AccountsDbContext context)
        {
            _context = context;
        }

        public async Task Add(UserIngredient userIngredient)
        {
            var x = await _context.UserIngredients.AddAsync(userIngredient);
            return;
        }
    }
}
*/
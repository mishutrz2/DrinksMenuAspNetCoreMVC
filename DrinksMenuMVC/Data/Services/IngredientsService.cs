using DrinksMenuMVC.Areas.Identity.Data;
using DrinksMenuMVC.Data.ViewModels;
using DrinksMenuMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

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

        public async Task<IDictionary<int, bool>> GetAvailabilities(string userId)
        {
            var result = new Dictionary<int, bool>();

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

        public async Task UpdateAvailable(List<int> myList, string userId)
        {

            // change stuff
            var allUserIngredients = _context.UserIngredients.Where(ui => ui.AccountUserId == userId).ToList();
            foreach(var userIngredient in allUserIngredients)
            {
                userIngredient.IsAvailable = false;
            }
            foreach (var userIngredient in allUserIngredients)
            {
                if (myList.Contains(userIngredient.IngredientId))
                userIngredient.IsAvailable = true;
            }

            // start transaction
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.UserIngredients.UpdateRange(allUserIngredients);
                    _context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }


        }



        //end of class
    }
}

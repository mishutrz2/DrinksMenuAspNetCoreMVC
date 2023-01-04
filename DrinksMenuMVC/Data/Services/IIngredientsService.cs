using DrinksMenuMVC.Data.ViewModels;
using DrinksMenuMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DrinksMenuMVC.Data.Services
{
    public interface IIngredientsService
    {
        Task<IEnumerable<Ingredient>> GetAll();
        Task<IEnumerable<Ingredient>> GetAvailableAll();
        Task<IDictionary<int, bool>> GetAvailabilities(string userId);

        Task UpdateAvailable(List<int> myList, string userId);
    }
}

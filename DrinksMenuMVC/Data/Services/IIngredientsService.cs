using DrinksMenuMVC.Models;

namespace DrinksMenuMVC.Data.Services
{
    public interface IIngredientsService
    {
        Task<IEnumerable<Ingredient>> GetAll();
        Task<IEnumerable<Ingredient>> GetAvailableAll();
        Task<IDictionary<int, bool>> GetAvailabilities(int userId);
        Ingredient GetById(int id);
    }
}

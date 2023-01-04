using DrinksMenuMVC.Models;

namespace DrinksMenuMVC.Data.Services
{
    public interface IIngredientsService
    {
        Task<IEnumerable<Ingredient>> GetAll();
        
    }
}

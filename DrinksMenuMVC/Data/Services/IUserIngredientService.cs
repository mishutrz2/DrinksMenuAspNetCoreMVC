using DrinksMenuMVC.Models;

namespace DrinksMenuMVC.Data.Services
{
    public interface IUserIngredientService
    {
        Task Add(UserIngredient userIngredient);
    }
}



using DrinksMenuMVC.Models;

namespace DrinksMenuMVC.Data.ViewModels
{
    // view model for checkbox list
    public class MyIngredientsViewModel
    {
        public IEnumerable<Ingredient> Ingredients { get; set; }
        public IDictionary<int, bool> IngredientAvailability { get; set; }
    }
}
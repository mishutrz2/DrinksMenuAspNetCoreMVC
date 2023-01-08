using DrinksMenuMVC.Data.Enums;
using DrinksMenuMVC.Models;

namespace DrinksMenuMVC.Data.ViewModels
{
    public class IngredientsAndTypeViewModel
    {
        public IEnumerable<Ingredient> Ingredients { get; set; }
        public DrinkType DrinkType { get; set; }
        public string DrinkDescription { get; set; }
        public string DrinkImageUrl { get; set; }
        public string DrinkName { get; set; }
        public IEnumerable<int> optionSelect { get; set; }
    }
}

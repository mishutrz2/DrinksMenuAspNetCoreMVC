using DrinksMenuMVC.Data.Enums;

namespace DrinksMenuMVC.Data.ViewModels
{
    public class AddDrinkViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DrinkType Type { get; set; }
        public string ImageUrl { get; set; }
        public DrinkStatus DrinkStatus { get; set; }
        public List<int> IngredientsIds { get; set; }

    }
}

namespace DrinksMenuMVC.Models
{
    public class DrinkIngredient
    {
        public int DrinkId { get; set; }
        public Drink Drink { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }

        // amount of ingredient for the drink in ml
        public int Amount { get; set; }
    }
}

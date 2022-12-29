namespace DrinksMenuMVC.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public string? Description { get; set; }
        public bool HasAlcohol { get; set; }
        public ICollection<DrinkIngredient> DrinkIngredients { get; set; }
        public ICollection<UserIngredient> UserIngredients { get; set; }
    }
}

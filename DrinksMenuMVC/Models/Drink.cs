namespace DrinksMenuMVC.Models
{
    public enum DrinkType
    {
        Cocktail,
        LongDrink,
        Shot,
        NonAlcoholic,
        Other
    }
    public class Drink
    {
        public int DrinkId { get; set; }
        public string DrinkName { get; set; }
        public DrinkType DrinkType { get; set; }
        public string Description { get; set; }
        public string DrinkImageUrl { get; set; }
        public List<Ingredient> DrinkIngredients { get; set; }
        public int AuthorId { get; set; }
    }
}

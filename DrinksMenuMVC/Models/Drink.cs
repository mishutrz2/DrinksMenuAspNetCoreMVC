namespace DrinksMenuMVC.Models
{
    public enum DrinkStatus
    {
        Pending,
        Approved,
        Rejected
    }
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
        public DrinkType TypeOfDrink { get; set; }
        public string? Description { get; set; }
        public string? DrinkImageUrl { get; set; }
        public DrinkStatus CurrentStatus { get; set; } = DrinkStatus.Pending;
        public ICollection<DrinkIngredient> DrinkIngredients { get; set; }

        // field for one-to-many relationship between User and Drink
        public User Author { get; set; }
        public int AuthorId { get; set; }
    }
}

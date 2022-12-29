namespace DrinksMenuMVC.Models
{
    public class UserIngredient
    {
        public int UserId { get; set; }
        public User User{ get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }

        // every user has it`s own list of available ingredients
        public bool IsAvailable { get; set; }
    }
}

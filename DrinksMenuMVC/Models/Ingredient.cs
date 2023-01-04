using System.ComponentModel.DataAnnotations;

namespace DrinksMenuMVC.Models
{
    public enum IngredientType
    {
        Spirits,
        Liqueurs,
        Sodas,
        Fruits,
        Bitters,
        Other
    }

    public class Ingredient
    {
        [Key]
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public string? Description { get; set; }
        public bool HasAlcohol { get; set; }
        public IngredientType IngredientType { get; set; }

        // this property corresponds to the many-to-many relationship between Drink and Ingredient
        public ICollection<DrinkIngredient> DrinkIngredients { get; set; }

        // this property corresponds to the many-to-many relationship between User and Ingredient
        public ICollection<UserIngredient> UserIngredients { get; set; }
    }
}

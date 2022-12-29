using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinksMenuMVC.Models
{
    public class DrinkIngredient
    {
        [Key]
        [Column(Order = 0)]
        public int DrinkId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int IngredientId { get; set; }
        public Drink Drink { get; set; }
        public Ingredient Ingredient { get; set; }

        // amount of ingredient for the drink in ml
        public int Amount { get; set; }
    }
}

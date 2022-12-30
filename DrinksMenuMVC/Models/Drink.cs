using DrinksMenuMVC.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinksMenuMVC.Models
{
    public class Drink
    {
        [Key]
        public int DrinkId { get; set; }
        public string DrinkName { get; set; }
        public DrinkType TypeOfDrink { get; set; }
        public string? Description { get; set; }
        public string? DrinkImageUrl { get; set; }
        public DrinkStatus CurrentStatus { get; set; } = DrinkStatus.Pending;

        // this property corresponds to the many-to-many relationship between Drink and Ingredient
        public ICollection<DrinkIngredient> DrinkIngredients { get; set; }

        // this property corresponds to the many-to-many relationship between User and Drink
        public ICollection<UserDrink> UserDrinks { get; set; }

        // field for one-to-many relationship between User and Drink
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserId { get; set; }
    }
}

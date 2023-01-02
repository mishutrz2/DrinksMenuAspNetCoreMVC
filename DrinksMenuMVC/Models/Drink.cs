using DrinksMenuMVC.Areas.Identity.Data;
using DrinksMenuMVC.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinksMenuMVC.Models
{
    public class Drink
    {
        [Key]
        public int DrinkId { get; set; }
        [Display(Name = "Drink Name")]
        public string DrinkName { get; set; }
        [Display(Name = "Type of Drink")]
        public DrinkType TypeOfDrink { get; set; }
        [Display(Name = "Description")]
        public string? Description { get; set; }
        [Display(Name = "Drink Image")]
        public string? DrinkImageUrl { get; set; }
        [Display(Name = "Status")]
        public DrinkStatus CurrentStatus { get; set; } = DrinkStatus.Pending;

        // this property corresponds to the many-to-many relationship between Drink and Ingredient
        [Display(Name = "Ingredients")]
        public ICollection<DrinkIngredient> DrinkIngredients { get; set; }

        // this property corresponds to the many-to-many relationship between User and Drink
        public ICollection<UserDrink> UserDrinks { get; set; }

        // field for one-to-many relationship between User and Drink
        [ForeignKey("UserId")]
        public AccountUser AccountUser { get; set; }
        public string AccountUserId { get; set; }
    }
}

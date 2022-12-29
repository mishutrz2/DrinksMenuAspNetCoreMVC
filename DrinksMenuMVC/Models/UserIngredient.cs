using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DrinksMenuMVC.Models
{
    public class UserIngredient
    {
        [Key]
        [Column(Order = 0)]
        public int UserId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int IngredientId { get; set; }
        public User User { get; set; }
        public Ingredient Ingredient { get; set; }

        // every user has it`s own list of available ingredients
        public bool IsAvailable { get; set; }
    }
}

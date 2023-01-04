using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DrinksMenuMVC.Areas.Identity.Data;

namespace DrinksMenuMVC.Models
{
    public class UserIngredient
    {
        [Key]
        [Column(Order = 0)]
        public string AccountUserId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int IngredientId { get; set; }
        public AccountUser AccountUser { get; set; }
        public Ingredient Ingredient { get; set; }

        // every user has it`s own list of available ingredients
        public bool IsAvailable { get; set; } = false;
    }
}

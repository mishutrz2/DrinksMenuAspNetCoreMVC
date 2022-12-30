using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinksMenuMVC.Models
{
    public class UserDrink
    {
        [Key]
        [Column(Order = 0)]
        public int UserId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int DrinkId { get; set; }
        public User User { get; set; }
        public Drink Drink { get; set; }
    }
}

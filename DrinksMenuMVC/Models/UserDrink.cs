using DrinksMenuMVC.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinksMenuMVC.Models
{
    public class UserDrink
    {
        [Key]
        [Column(Order = 0)]
        public string AccountUserId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int DrinkId { get; set; }
        public AccountUser AccountUser { get; set; }
        public Drink Drink { get; set; }
    }
}

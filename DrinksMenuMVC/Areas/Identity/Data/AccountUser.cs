using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinksMenuMVC.Models;
using Microsoft.AspNetCore.Identity;

namespace DrinksMenuMVC.Areas.Identity.Data;

// Add profile data for application users by adding properties to the AccountUser class
public class AccountUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DisplayName { get; set; }

    // this property corresponds to the one-to-many relationship between User and Drink
    public ICollection<Drink> PostedDrinks { get; set; }

    // this property corresponds to the many-to-many relationship between User and Ingredient
    public ICollection<UserIngredient> UserIngredients { get; set; }

    // this property corresponds to the many-to-many relationship between User and Drink
    public ICollection<UserDrink> UserDrinks { get; set; }
}


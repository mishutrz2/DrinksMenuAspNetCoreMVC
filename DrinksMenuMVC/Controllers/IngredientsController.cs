using DrinksMenuMVC.Areas.Identity.Data;
using DrinksMenuMVC.Data;
using DrinksMenuMVC.Data.Services;
using DrinksMenuMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DrinksMenuMVC.Controllers
{
    [Authorize]
    public class IngredientsController : Controller
    {
        private readonly IIngredientsService _service;
        private readonly UserManager<AccountUser> _userManager;

        public IngredientsController(IIngredientsService service, UserManager<AccountUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        public async Task<IActionResult> MyIngredients()
        {
            // Get ingredients that are available for a certain user
            AccountUser accountUser = await _userManager.GetUserAsync(User);
            string userId = string.Empty;
            try
            {
                userId = accountUser.Id;
            }
            catch (Exception ex)
            {
                return View();
            }

            return View();
        }


        // end of class
    }
}

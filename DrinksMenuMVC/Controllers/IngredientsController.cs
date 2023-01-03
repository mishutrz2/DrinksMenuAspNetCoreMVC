using DrinksMenuMVC.Areas.Identity.Data;
using DrinksMenuMVC.Data;
using DrinksMenuMVC.Data.Services;
using DrinksMenuMVC.Data.ViewModels;
using DrinksMenuMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DrinksMenuMVC.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly IIngredientsService _service;
        private readonly UserManager<AccountUser> _userManager;

        public IngredientsController(IIngredientsService service, UserManager<AccountUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var allIngredients = await _service.GetAll();
            return View(allIngredients);
        }

        public async Task<IActionResult> MyIngredients()
        {
            // Get ingredients that are available for a certain user
            AccountUser accountUser = await _userManager.GetUserAsync(User);
            string userId = accountUser.Id;

            // Get the ingredients
            var ingredients = await _service.GetAvailableAll();

            // Get the dictionary for availability
            var ingredientAvailability = await _service.GetAvailabilities(userId);

            MyIngredientsViewModel viewModel = new()
            {
                Ingredients = ingredients,
                IngredientAvailability = ingredientAvailability
            };

            return View(viewModel);
        }
    }
}

using DrinksMenuMVC.Data;
using DrinksMenuMVC.Data.Services;
using DrinksMenuMVC.Data.ViewModels;
using DrinksMenuMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DrinksMenuMVC.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly IIngredientsService _service;

        public IngredientsController(IIngredientsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allIngredients = await _service.GetAll();
            return View(allIngredients);
        }

        public async Task<IActionResult> MyIngredients()
        {
            // Get ingredients that are available for a certain user
            // set the UserId to 2; will take care of which user is logged in later
            int userId = 2;

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

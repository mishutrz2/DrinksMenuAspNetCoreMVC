using DrinksMenuMVC.Areas.Identity.Data;
using DrinksMenuMVC.Data;
using DrinksMenuMVC.Data.Services;
using DrinksMenuMVC.Data.ViewModels;
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

        [HttpPost]
        public async Task<IActionResult> Save([FromForm]SaveMyIngredientsViewModel myIngredientsViewModel)
        {
            AccountUser accountUser = await _userManager.GetUserAsync(User);
            string userId = accountUser.Id;

            // Save the model and then redirect to another page 
            await _service.UpdateAvailable(myIngredientsViewModel.Ids, userId);
            Console.WriteLine(myIngredientsViewModel);
            return View();
        }

        // end of class
    }
}

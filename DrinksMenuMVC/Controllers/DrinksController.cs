using DrinksMenuMVC.Areas.Identity.Data;
using DrinksMenuMVC.Data;
using DrinksMenuMVC.Data.Services;
using DrinksMenuMVC.Data.ViewModels;
using DrinksMenuMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DrinksMenuMVC.Controllers
{
    public class DrinksController : Controller
    {
        private readonly IDrinksService _service;
        private readonly IIngredientsService _ingredientsService;
        private readonly UserManager<AccountUser> _userManager;

        public DrinksController(IDrinksService service, IIngredientsService ingredientsService, UserManager<AccountUser> userManager)
        {
            _service = service;
            _ingredientsService = ingredientsService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var allDrinks = await _service.GetAll();
            return View(allDrinks);
        }

        public async Task<IActionResult> IndexCards()
        {
            // Get drinks that are available for a certain user
            AccountUser accountUser = await _userManager.GetUserAsync(User);
            string userId = "123";
            try
            {
                userId = accountUser.Id;
            }
            catch (Exception ex)
            {
                
            }
            
            var availableCards = await _service.GetAllAvailableCards(userId);
            var unavailableCards = await _service.GetAllUnavailableCards(userId);
            return View(new Tuple<IEnumerable<Drink>, IEnumerable<Drink>>(availableCards, unavailableCards));
        }

        public IActionResult Home()
        {
            return View();
        }

        public async Task<IActionResult> AddDrink()
        {
            IngredientsAndTypeViewModel ingredients = new IngredientsAndTypeViewModel()
            {
                Ingredients = await _ingredientsService.GetAll()
            };

            return View(ingredients);
        }

        public async Task<PartialViewResult> GetPartialView()
        {
            var model = new IngredientsAndTypeViewModel();
            model.Ingredients = await _ingredientsService.GetAll();

            return PartialView("_AddIngredient", model);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] IngredientsAndTypeViewModel payload)
        {
            AccountUser accountUser = await _userManager.GetUserAsync(User);
            string userId = accountUser.Id;


            Drink createdDrink = new Drink()
            {
                DrinkName = payload.DrinkName,
                Description = payload.DrinkDescription,
                DrinkImageUrl = payload.DrinkImageUrl,
                TypeOfDrink = payload.DrinkType
                
            };

            await _service.AddDrink(createdDrink, userId);
            await _service.AddDrinkIngredients(payload.DrinkName, payload.optionSelect);
            return View();
        }
    }
}

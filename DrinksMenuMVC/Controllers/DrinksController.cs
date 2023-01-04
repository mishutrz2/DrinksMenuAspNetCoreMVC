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
    public class DrinksController : Controller
    {
        private readonly IDrinksService _service;
        private readonly UserManager<AccountUser> _userManager;

        public DrinksController(IDrinksService service, UserManager<AccountUser> userManager)
        {
            _service = service;
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

        [Authorize(Policy = "RequireContributorRole")]
        public IActionResult AddDrink()
        {
            return View();
        }
    }
}

using DrinksMenuMVC.Data;
using DrinksMenuMVC.Data.Services;
using DrinksMenuMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DrinksMenuMVC.Controllers
{
    public class DrinksController : Controller
    {
        private readonly IDrinksService _service;

        public DrinksController(IDrinksService service)
        {
            _service = service; 
        }

        public async Task<IActionResult> Index()
        {
            var allDrinks = await _service.GetAll();
            return View(allDrinks);
        }

        public async Task<IActionResult> IndexCards()
        {
            // Get drinks that are available for a certain user
            // set the UserId to 2; will take care of which user is logged in later
            int userId = 2;

            var availableCards = await _service.GetAllAvailableCards(userId);
            var unavailableCards = await _service.GetAllUnavailableCards(userId);
            return View(new Tuple<IEnumerable<Drink>, IEnumerable<Drink>>(availableCards, unavailableCards));
        }

        public IActionResult Home()
        {
            return View();
        }
    }
}

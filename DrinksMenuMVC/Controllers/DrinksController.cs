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
            var allDrinksCards = await _service.GetAllCards();
            return View(allDrinksCards);
        }

        public IActionResult Home()
        {
            return View();
        }
    }
}

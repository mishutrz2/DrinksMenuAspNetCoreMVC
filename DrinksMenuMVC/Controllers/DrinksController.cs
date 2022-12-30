using DrinksMenuMVC.Data;
using DrinksMenuMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DrinksMenuMVC.Controllers
{
    public class DrinksController : Controller
    {
        private readonly AppDbContext _context;

        public DrinksController(AppDbContext context)
        {
            _context = context; 
        }

        public async Task<IActionResult> Index()
        {
            var allDrinks = await _context.Drinks.Include(d => d.DrinkIngredients).ToListAsync();
            return View(allDrinks);
        }

        public async Task<IActionResult> IndexCards()
        {
            var allDrinks = await _context.Drinks.Include(d => d.User).Include(d => d.DrinkIngredients).ThenInclude(i => i.Ingredient).ToListAsync();
            return View(allDrinks);
        }
    }
}

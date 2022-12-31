using DrinksMenuMVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DrinksMenuMVC.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly AppDbContext _context;

        public IngredientsController(AppDbContext context)
        {
                _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allIngredients = await _context.Ingredients.ToListAsync();
            return View(allIngredients);
        }

        public async Task<IActionResult> MyIngredients()
        {
            var allIngredients = await _context.Ingredients.ToListAsync();
            return View(allIngredients);
        }
    }
}

using DrinksMenuMVC.Models;

namespace DrinksMenuMVC.Data.Services
{
    public interface IDrinksService
    {
        Task<IEnumerable<Drink>> GetAll();
        Task<IEnumerable<Drink>> GetAllCards();
        Drink GetById(int id);
        void Add(Drink drink);
        Drink Update(int id, Drink newDrink);
        void Delete(int id);
    }
}

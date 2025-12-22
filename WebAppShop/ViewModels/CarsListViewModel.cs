using WebAppShop.Data.Models;

namespace WebAppShop.ViewModels
{
    public class CarsListViewModel
    {
        internal string currCategory;

        public IEnumerable<Car> AllCars { get; set; } 
        public string? Title { get; set; }
    }
}

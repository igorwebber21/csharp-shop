using WebAppShop.Data.Models;

namespace WebAppShop.ViewModels
{
    public class CarsListViewModel
    {
        public IEnumerable<Car> AllCars { get; set; } 
        public string? Title { get; set; }
    }
}

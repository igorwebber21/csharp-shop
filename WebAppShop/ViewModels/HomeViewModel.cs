using WebAppShop.Data.Models;

namespace WebAppShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Car>? FavCars { get; set; }

        public string? Title { get; set; }
    }
}

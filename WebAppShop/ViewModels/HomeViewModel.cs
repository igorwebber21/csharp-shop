using WebAppShop.Data.Interfaces;
using WebAppShop.Data.Models;

namespace WebAppShop.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public IEnumerable<Car>? FavCars { get; set; }

        public string? Title { get; set; }

    }
}

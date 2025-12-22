using WebAppShop.Data.Models;

namespace WebAppShop.Data.Interfaces
{
    public interface ICars
    {
        IEnumerable<Car> Cars { get; set; }
        IEnumerable<Car> FavoriteCars { get; set; } 
        Car? GetCarById(int carId);

    }
}

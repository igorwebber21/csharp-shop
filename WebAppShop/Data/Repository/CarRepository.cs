using Microsoft.EntityFrameworkCore;
using WebAppShop.Data.Interfaces;
using WebAppShop.Data.Models;

namespace WebAppShop.Data.Repository
{
    public class CarRepository : ICars
    {
        private readonly AppDBContent? _content;

        public CarRepository(AppDBContent? content)
        {
            _content = content;
        }

        // Возвращает все автомобили.
        // При отсутствии контекста возвращается пустая коллекция.
        public IEnumerable<Car> Cars
        {
            get
            {
                if (_content == null)
                {
                    return Enumerable.Empty<Car>();
                }

                return _content.Car.Include(c => c.Category);
            }
            set => throw new NotImplementedException();
        }

        // Возвращает автомобили, помеченные как избранные
        public IEnumerable<Car> FavoriteCars {
            get
            {
                if (_content == null)
                {
                    return Enumerable.Empty<Car>();
                }

                return _content.Car.Where(p => p.IsFavourite).Include(c => c.Category);

            } 
            set => throw new NotImplementedException(); 
        }

        // Возвращает автомобиль по его ID
        public Car? GetCarById(int carId)
        {
            if (_content == null)
            {
                return null;
            }

            return _content.Car.FirstOrDefault(p => p.Id == carId);
        }
    }
}

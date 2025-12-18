using WebAppShop.Data.Interfaces;
using WebAppShop.Data.Models;

namespace WebAppShop.Data.Mocks
{
    public class MockCars : ICars
    {
        // Создаем экземпляр MockCategory для получения категорий автомобилей
        private readonly ICarsCategory _categoryCars = new MockCategory();

        public IEnumerable<Car> Cars {
            get
            {
                return new List<Car>
                {
                    new Car
                    {
                        Name = "Tesla Model S",
                        ShortDesc = "Быстрый электромобиль",
                        LongDesc = "Tesla Model S - это полностью электрический автомобиль, известный своей высокой производительностью и дальностью хода.",
                        Img = "/img/tesla_model_s.jpg",
                        Price = 65535,
                        IsFavourite = true,
                        Available = true,
                        Category = _categoryCars.AllCategories.First()
                    },
                    new Car
                    {
                        Name = "Ford Mustang",
                        ShortDesc = "Классический американский мускулкар",
                        LongDesc = "Ford Mustang - это икона американского автомобилестроения, известная своим мощным двигателем и стильным дизайном.",
                        Img = "/img/ford_mustang.jpg",
                        Price = 55999,
                        IsFavourite = false,
                        Available = true,
                        Category = _categoryCars.AllCategories.Last()
                    }
                };
            }

            set {                 
                throw new NotImplementedException();
            }
        }
        public IEnumerable<Car> FavoriteCars { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Car GetCarById(int carId)
        {
            throw new NotImplementedException();
        }
    }
}

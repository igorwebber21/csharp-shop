using WebAppShop.Data.Interfaces;
using WebAppShop.Data.Models;
using System.Collections.Generic;

namespace WebAppShop.Data.Mocks
{
    // Реализация интерфейса ICarsCategory
    public class MockCategory : ICarsCategory
    {
        // Возвращает все категории автомобилей
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category { Id = 1, Name = "Электромобили", Description = "Современный вид транспорта", Cars = new List<Car>() },
                    new Category { Id = 2, Name = "Классические автомобили", Description = "Автомобили с двигателем внутреннего сгорания", Cars = new List<Car>() }
                };
            }
        }
    }
}

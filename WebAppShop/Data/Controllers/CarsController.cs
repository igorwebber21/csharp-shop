using Microsoft.AspNetCore.Mvc;
using WebAppShop.Data.Interfaces;
using WebAppShop.Data.Models;
using WebAppShop.ViewModels; 

namespace WebAppShop.Data.Controllers
{
    // Префикс маршрута для контроллера — будет использоваться как начало пути
    [Route("Cars")]
    public class CarsController : Controller
    {
        private readonly ICars _allCars;
        private readonly ICarsCategory _allCategories;

        public CarsController(ICars iCars, ICarsCategory iCarsCategory)
        {
            _allCars = iCars;
            _allCategories = iCarsCategory;
        }

        // Маршрут: /Cars/List и /Cars/List/{category} (category необязателен)
        [HttpGet("List/{category?}")]
        public IActionResult List(string category) 
        {
            string _category = category;
            IEnumerable<Car> cars = null;
            string currCategory = "";

            if(string.IsNullOrEmpty(category))
            {
                cars = _allCars.Cars.OrderBy(i => i.Id);
            }
            else
            {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.Name.Equals("Электромобили")).OrderBy(i => i.Id);
                }
                else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.Name.Equals("Классические автомобили")).OrderBy(i => i.Id);
                }

                currCategory = _category;
            }



            // вместо передачи списка авто напрямую _allCars.Cars  в представление,    
            // создадим объект CarsListViewModel
            // и передадим его в представление через метод View()
            var carObj = new CarsListViewModel
            {
                AllCars = cars,
                currCategory = currCategory,
                Title = "Список авто"
            };


            ViewBag.PageTitle = "Страница списка авто";

            return View(carObj);
            //   return View(_allCars.Cars);
        }

    }
}

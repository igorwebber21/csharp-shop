using Microsoft.AspNetCore.Mvc;
using WebAppShop.Data.Interfaces;
using WebAppShop.ViewModels; 

namespace WebAppShop.Data.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICars _allCars;
        private readonly ICarsCategory _allCategories;

        public CarsController(ICars iCars, ICarsCategory iCarsCategory)
        {
            _allCars = iCars;
            _allCategories = iCarsCategory;
        }

        public IActionResult List() 
        {
            ViewBag.PageTitle = "Страница списка авто";

            // вместо передачи списка авто напрямую _allCars.Cars  в представление,    
            // создадим объект CarsListViewModel
            // и передадим его в представление

            CarsListViewModel carsListViewModel = new CarsListViewModel
            {
                AllCars = _allCars.Cars,
                Title = "Список авто"
            };

            return View(carsListViewModel);
            //   return View(_allCars.Cars);
        }

    }
}

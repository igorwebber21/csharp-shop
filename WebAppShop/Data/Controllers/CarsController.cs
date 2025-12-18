using Microsoft.AspNetCore.Mvc;
using WebAppShop.Data.Interfaces;

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

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppShop.Data.Interfaces;
using WebAppShop.ViewModels;

namespace WebAppShop.Data.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICars? _carRepository; 

        public HomeController(ICars? carRepository)
        {
            _carRepository = carRepository; 
        }

        // GET: HomeController
        public ViewResult Index()
        {
            ViewBag.PageTitle = "Главная";

            var homeCars = new HomeViewModel
            {
                FavCars = _carRepository?.FavoriteCars,
                Title = "Избранные авто"
            }; 

            return View(homeCars);
        } 
    }
}

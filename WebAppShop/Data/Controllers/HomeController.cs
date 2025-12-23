using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppShop.Data.Interfaces;
using WebAppShop.ViewModels;

namespace WebAppShop.Data.Controllers
{
    public class HomeController : BaseController
    {

        private readonly ICars? _carRepository;

        public HomeController(ICars carRepository, ICarsCategory сategories) : base(сategories)
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
                AllCategories = Categories,
                Title = "Избранные авто"
            }; 

            return View(homeCars);
        } 
    }
}

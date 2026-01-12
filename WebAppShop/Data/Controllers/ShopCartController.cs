using Microsoft.AspNetCore.Mvc;
using WebAppShop.Data.Interfaces;
using WebAppShop.Data.Models; 
using WebAppShop.ViewModels;

namespace WebAppShop.Data.Controllers
{
    public class ShopCartController : BaseController
    {
        private readonly ICars? _carRepository;
        private readonly ShopCart? _shopCart;

        public ShopCartController(ICars? carRepository, ShopCart? shopCart, ICarsCategory сategories) : base(сategories)
        {
            _carRepository = carRepository;
            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var items = _shopCart?.GetShopItems() ?? new List<ShopCartItem>();

            if (_shopCart != null)
            {
                _shopCart.ListShopItems = items;

                var obj = new ShopCartViewModel{
                  ShopCart = _shopCart,
                  AllCategories = Categories
                };

                return View(obj);
            }
            // Предполагается, что здесь должен быть возврат ViewResult, например:
            // return View(_shopCart);
            // Но если это не требуется, оставьте как есть.
            return null!;
        }

        // Добавление товара в корзину
        public RedirectToActionResult AddToCart(int carId)
        {
            // Получаем выбранный товар по его id
            var selectedCar = _carRepository?.Cars.FirstOrDefault(p => p.Id == carId);

            // Если товар найден, добавляем его в корзину
            if (selectedCar != null && _shopCart != null)
            {
                _shopCart.AddToCart(selectedCar);
            }

            // Перенаправляем пользователя на страницу корзины
            return RedirectToAction("Index");
        }
    }
}
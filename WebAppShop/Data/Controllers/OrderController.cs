using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using WebAppShop.Data.Interfaces;
using WebAppShop.Data.Models; 
using WebAppShop.ViewModels;

namespace WebAppShop.Data.Controllers
{
    public class OrderController : BaseController
    { 
        private readonly ShopCart? shopCart;
        private readonly IOrders? orders; 

        public OrderController(IOrders orders, ShopCart shopCart, ICarsCategory allCategories) : base(allCategories)
        {
            this.orders = orders;
            this.shopCart = shopCart;
        } 

        public IActionResult Checkout()
        { 
            var obj = new OrderViewModel
            { 
                AllCategories = Categories
            };

            return View(obj); 
        }

        [HttpPost]
        public IActionResult Checkout(OrderViewModel model)
        {
            var order = model.Orders;

            Console.WriteLine("Order Details:"); 
            Console.WriteLine($"Name: {order.Name}");

            shopCart.ListShopItems = shopCart.GetShopItems();

            Console.WriteLine($"Order ListShopItemsCount:  {shopCart.ListShopItems.Count}");
 
            if (shopCart == null || shopCart.ListShopItems == null || shopCart.ListShopItems.Count == 0)
            {
                Console.WriteLine("Error ListShopItems Count");
                ModelState.AddModelError("", "У вас нет товаров в заказе");
            }

            // проверка модели (полей формы) на валидность
            if (!ModelState.IsValid)
             {
                Console.WriteLine("Error ModelState");
                foreach (var entry in ModelState)
                {
                    foreach (var error in entry.Value.Errors)
                    {
                        Console.WriteLine($"Field: {entry.Key}, Error: {error.ErrorMessage}");
                    }
                }
                model.AllCategories = Categories;
                 return View(model);
             }  

             if (order == null)
             {
                 ModelState.AddModelError("", "Ошибка: данные клиента заказа отсутствуют");
                 model.AllCategories = Categories;
                 return View(model);
             }

             try
             {
                 Console.WriteLine("Попытка создания заказа..."); 
                 orders.CreateOrder(order);
                 Console.WriteLine("Заказ успешно создан");
             }
             catch (Exception ex)
             {
                 Console.WriteLine($"Ошибка при создании заказа: {ex.Message}");
                 ModelState.AddModelError("", "Ошибка при создании заказа");
                 model.AllCategories = Categories;
                 return View(model);
             }

             return RedirectToAction("Complete"); 
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";

            var obj = new OrderViewModel
            {
                Orders = new Order(),
                AllCategories = Categories
            }; 

            return View(obj);
        }
    }
}

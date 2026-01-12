using Microsoft.AspNetCore.Http.HttpResults;
using WebAppShop.Data.Interfaces;
using WebAppShop.Data.Models;

namespace WebAppShop.Data.Repository
{
    public class OrdersRepository : IOrders
    {
        private readonly AppDBContent? _content;
        private readonly ShopCart? shopCart;

        public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart)
        {
            _content = appDBContent;
            this.shopCart = shopCart;
        }

        public void CreateOrder(Order order)
        {
            Console.WriteLine("CreateOrder SaveChanges()");

            order.OrderTime = DateTime.Now;
            _content.Order.Add(order);
            _content.SaveChanges();


            // Ensure ListShopItems is populated
            shopCart.ListShopItems = shopCart.GetShopItems();

            var items = shopCart.GetShopItems() ?? new List<ShopCartItem>();

            foreach (var item in items) 
            {
                var orderDetail = new OrderDetail
                {
                    CarId = item.Car.Id,
                    OrderId = order.Id,
                    Price = item.Car.Price
                };

                _content.OrderDetail.Add(orderDetail);
            }

            _content.SaveChanges(); 
        } 
    }
}

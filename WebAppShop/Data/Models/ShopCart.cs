using Microsoft.EntityFrameworkCore;

namespace WebAppShop.Data.Models
{
    public class ShopCart
    {
        private readonly AppDBContent? _content;

        public ShopCart(AppDBContent? content)
        {
            _content = content;
        }

        public string ShopCartId { get; set; }
        public List<ShopCartItem> ListShopItems { get; set; }

        // Получаем корзину для текущей сессии
        public static ShopCart GetCart(IServiceProvider serviceProvider)
        {
            // Получаем сессию
            ISession? session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;
            var context = serviceProvider.GetService<AppDBContent>();

            // Получаем или создаем идентификатор корзины
            string shopCartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();
            session?.SetString("CartId", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        // Добавляем товар в корзину
        public void AddToCart(Car car)
        {
            if (_content == null) return;

            _content.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                Car = car,
                Price = car.Price
            });

            _content.SaveChanges();
        }

        // Получаем все элементы корзины для текущей корзины
        public List<ShopCartItem> GetShopItems()
        {
            if (_content == null) return new List<ShopCartItem>();

            return _content.ShopCartItem
                .Where(c => c.ShopCartId == ShopCartId)
                .Include(s => s.Car)
                .ToList();
        }
    }
}

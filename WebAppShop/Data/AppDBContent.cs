using Microsoft.EntityFrameworkCore;
using WebAppShop.Data.Models;

namespace WebAppShop.Data
{
    public class AppDBContent : DbContext
    {
        // Конструктор класса, принимающий параметры конфигурации контекста базы данных
        public AppDBContent(DbContextOptions<AppDBContent> options) : base (options)
        {

        }

        // Создаем таблицы в базе данных для моделей Car, Category и ShopCartItem
        public DbSet<Car> Car { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<ShopCartItem> ShopCartItem { get; set; }

    }
}

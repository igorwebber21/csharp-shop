using Microsoft.EntityFrameworkCore;
using WebAppShop.Data;
using WebAppShop.Data.Interfaces;
using WebAppShop.Data.Mocks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebAppShop.Data.Repository;
using WebAppShop.Data.Models;

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args); 

        // Подключаем кастомный json с connection string DB
        builder.Configuration.AddJsonFile("dbsettings.json", optional: false, reloadOnChange: true);

        // Регистрация MVC (Controllers + Views)
        builder.Services.AddControllersWithViews();

        // Регистрируем DbContext с connection string из dbsettings.json
        builder.Services.AddDbContext<AppDBContent>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Регистрация сервиса для работы с автомобилями и  категориями автомобилей (From Mocks)
       // builder.Services.AddTransient<ICars, MockCars>(); 
       // builder.Services.AddTransient<ICarsCategory, MockCategory>();

        // Регистрация сервиса для работы с автомобилями и  категориями автомобилей (From Repository)
        builder.Services.AddTransient<ICars, CarRepository>();
        builder.Services.AddTransient<ICarsCategory, CategoryRepository>(); 
        builder.Services.AddTransient<IOrders, OrdersRepository>();

        // Регистрация сервиса для работы с корзиной покупок
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddScoped(sp => ShopCart.GetCart(sp));

        // Регистрация кэша и сессий
        builder.Services.AddMemoryCache();
        builder.Services.AddSession();


        var app = builder.Build();

        /* using (var scope = app.Services.CreateScope())
         {
             var services = scope.ServiceProvider;
             var logger = services.GetRequiredService<ILogger<Program>>();

             logger.LogInformation("Start program");
             try
             {
                 var db = services.GetRequiredService<AppDBContent>();
                 if (db.Database.CanConnect())
                 {
                     logger.LogInformation("Database 'Shop' connected successfully.");
                 }
                 else
                 {
                     logger.LogError("Cannot connect to database 'Shop'.");
                 }
             }
             catch (Exception ex)
             {
                 logger.LogError(ex, "Exception while checking DB connection.");
             }
         }
        */

        // Статические файлы и маршрутизация для MVC
        app.UseStaticFiles();
        app.UseRouting();

        // Активируем сессии
        app.UseSession();

        app.UseAuthorization();

        // добавляем страницы ошибок
        app.UseDeveloperExceptionPage();
        app.UseStatusCodePages();

        // Существующий минимальный маршрут остаётся
        //app.MapGet("/", () => app.Environment.IsProduction() ? "Prod" : app.Environment.EnvironmentName);

        // Явный маршрут: /Cars/List и /Cars/List/{category} (category необязателен)
        app.MapControllerRoute(
            name: "cars_list",
            pattern: "Cars/{action}/{category?}",
            defaults: new { controller = "Cars", action = "List" });

        // Маршрут по умолчанию для MVC
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");


        // Инициализация таблиц базы данных с начальными данными
        using (var scope = app.Services.CreateScope())
        {
            AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
            DBObjects.Initial(content);
        }


        app.Run();
    }
}
using WebAppShop.Data.Interfaces;
using WebAppShop.Data.Mocks;

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Регистрация MVC (Controllers + Views)
        builder.Services.AddControllersWithViews();

        // Регистрация сервиса для работы с автомобилями
        builder.Services.AddTransient<ICars, MockCars>();

        // Регистрация сервиса для работы с категориями автомобилей
        builder.Services.AddTransient<ICarsCategory, MockCategory>();

        var app = builder.Build();

        // Статические файлы и маршрутизация для MVC
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();

        // добавляем страницы ошибок
        app.UseDeveloperExceptionPage();
        app.UseStatusCodePages();

        // Существующий минимальный маршрут остаётся
        app.MapGet("/", () => app.Environment.IsProduction() ? "Prod" : app.Environment.EnvironmentName);

        // Маршрут по умолчанию для MVC
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
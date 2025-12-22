using WebAppShop.Data.Models;
using WebAppShop.Migrations;

namespace WebAppShop.Data
{
    public class DBObjects
    {
        public static void Initial  (AppDBContent content)
        {
            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }

            if (!content.Car.Any())
            {
                content.Car.AddRange(
                       new Car
                       {
                           Name = "Tesla Model S",
                           ShortDesc = "Быстрый электромобиль",
                           LongDesc = "Tesla Model S - это полностью электрический автомобиль, известный своей высокой производительностью и дальностью хода.",
                           Img = "/img/cars/tesla.jpg",
                           Price = 65535,
                           IsFavourite = true,
                           Available = true,
                           Category = Categories["Электромобили"]
                       },
                        new Car
                        {
                            Name = "Ford Mustang",
                            ShortDesc = "Классический американский мускулкар",
                            LongDesc = "Ford Mustang - это икона американского автомобилестроения, известная своим мощным двигателем и стильным дизайном.",
                            Img = "/img/cars/mustang.jpg",
                            Price = 55999,
                            IsFavourite = false,
                            Available = true,
                            Category = Categories["Классические автомобили"]
                        }
                );
            }

            // Сохраняем изменения в базе данных
            content.SaveChanges();

        }


        private static Dictionary<string, Category>? category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
               if(category == null)     
                {
                    var list = new Category[]
                    {
                        new Category{ Name="Электромобили", Description="Современный вид транспорта"},
                        new Category{ Name="Классические автомобили", Description="Машины с двигателем внутреннего сгорания"}
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                    {
                        category.Add(el.Name, el);
                    }
                }

               return category;
            }
        }
    }
}

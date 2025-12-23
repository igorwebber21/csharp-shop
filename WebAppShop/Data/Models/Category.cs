namespace WebAppShop.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public List<Car> Cars { get; set; }

    }
}

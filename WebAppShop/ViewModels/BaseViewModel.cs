using WebAppShop.Data.Models;

namespace WebAppShop.ViewModels
{
    public class BaseViewModel
    {
        public IEnumerable<Category> AllCategories { get; set; }
    }
}

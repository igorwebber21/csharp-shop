using WebAppShop.Data.Models;

namespace WebAppShop.ViewModels
{
    public class ShopCartViewModel : BaseViewModel
    {
        public ShopCart? ShopCart { get; set; }
        public int TotalPrice { get; set; }
        public string? Title { get; set; }
    }
}
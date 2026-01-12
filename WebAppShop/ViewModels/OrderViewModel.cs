using WebAppShop.Data.Interfaces;
using WebAppShop.Data.Models;

namespace WebAppShop.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        public  Order? Orders { get; set; }
    }
}

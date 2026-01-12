using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using WebAppShop.Data.Models;

namespace WebAppShop.ViewModels
{
    public class BaseViewModel
    {
        [ValidateNever]
        public IEnumerable<Category> AllCategories { get; set; }
    }
}

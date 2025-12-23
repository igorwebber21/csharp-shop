using Microsoft.AspNetCore.Mvc;
using WebAppShop.Data.Interfaces;
using WebAppShop.Data.Models;

namespace WebAppShop.Data.Controllers
{
    public abstract class BaseController : Controller
    {
        protected ICarsCategory _allCategories;

        protected BaseController(ICarsCategory allCategories)
        {
            _allCategories = allCategories;
        }

        protected IEnumerable<Category> Categories =>
            _allCategories.AllCategories.OrderBy(i => i.Id);
    }
}

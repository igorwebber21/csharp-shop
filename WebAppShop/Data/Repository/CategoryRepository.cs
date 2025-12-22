using Microsoft.EntityFrameworkCore;
using WebAppShop.Data.Interfaces;
using WebAppShop.Data.Models;

namespace WebAppShop.Data.Repository
{
    public class CategoryRepository : ICarsCategory
    {
        private readonly AppDBContent? _content;

        public CategoryRepository(AppDBContent? content)
        {
            _content = content;
        } 

        public IEnumerable<Category> AllCategories
        {
            get
            {
                if (_content == null)
                {
                    return Enumerable.Empty<Category>();
                }

                return _content.Category;
            }
        }
    }
}

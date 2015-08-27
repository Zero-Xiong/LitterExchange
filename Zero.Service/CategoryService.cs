using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.Data;
using Zero.Model;

namespace Zero.Service
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();

        IEnumerable<Category> GetCategoriesByDefaultSorting();

        Category GetCategory(string Id);
    }

    public class CategoryService : ICategoryService
    {
        private LitterDbContext context;

        public CategoryService()
        {
            context = new LitterDbContext();
        }

        public CategoryService(LitterDbContext _context)
        {
            context = _context;
        }

        public IEnumerable<Category> GetCategories()
        {
            return context.Categorys.ToList();
        }

        public IEnumerable<Category> GetCategoriesByDefaultSorting()
        {
            return context.Categorys.Where(c => c.IsEnabled).OrderBy(c => new { c.Sequence, c.Name });
        }

        public Category GetCategory(string Id)
        {
            return context.Categorys.Find(Id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.Data.Infrastructure;
using Zero.Model;

namespace Zero.Data.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> GetCategoriesByDefaultSorting();
    }

    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(IUnitOfWork unit) : base(unit)
        {
        }

        public IEnumerable<Category> GetCategoriesByDefaultSorting()
        {
            return this.dbSet.Where(c => c.IsEnabled).OrderBy(c => new { c.Sequence, c.Name });
        }
    }
}

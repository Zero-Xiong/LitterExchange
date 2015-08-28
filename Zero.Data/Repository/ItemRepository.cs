using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.Data.Infrastructure;
using Zero.Model;

namespace Zero.Data.Repository
{
    public interface IItemRepository : IRepository<Item>
    {
        IEnumerable<Item> GetItemsByPage(int currentPage, int noOfRecords, string sortBy, string filterBy);

        IEnumerable<Item> GetItemsByCategoryPage(string categoryId, int currentPage, int noOfRecords, string sortBy, string filterBy);

        IEnumerable<Item> GetItemsByCategoryPage(Category category, int currentPage, int noOfRecords, string sortBy, string filterBy);
    }

    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(IUnitOfWork unit) : base(unit)
        {
        }

        public IEnumerable<Item> GetItemsByCategoryPage(Category category, int currentPage, int noOfRecords, string sortBy, string filterBy)
        {
            if (category == null)
                return null;

            IEnumerable<Item> items = null;
            if (!string.IsNullOrEmpty(filterBy))
                items = this.UnitOfWork.Db.Entry(category).Collection(i => i.Items).Query().Where(i => i.Title.Contains(filterBy) || i.Description.Contains(filterBy));
            else
                items = this.UnitOfWork.Db.Entry(category).Collection(i => i.Items).Query();

            items = (sortBy.ToLower() == "datecreated") ? this.dbSet.OrderByDescending(i => i.DateCreated) : this.dbSet.OrderBy(i => i.Title);
            return items.Skip(noOfRecords * currentPage).Take(noOfRecords);
        }

        public IEnumerable<Item> GetItemsByCategoryPage(string categoryId, int currentPage, int noOfRecords, string sortBy, string filterBy)
        {
            if (string.IsNullOrWhiteSpace(categoryId))
                return null;

            var category = this.UnitOfWork.Db.Set<Category>().SingleOrDefault(c=> string.Compare(categoryId, c.Id.ToString(), true) == 0);

            return this.GetItemsByCategoryPage(category, currentPage, noOfRecords, sortBy, filterBy);
        }

        public IEnumerable<Item> GetItemsByPage(int currentPage, int noOfRecords, string sortBy, string filterBy)
        {
            IEnumerable<Item> items = null;
            if (!string.IsNullOrEmpty(filterBy))
                items = this.dbSet.Where(i => i.Title.Contains(filterBy) || i.Description.Contains(filterBy));
            else
                items = (sortBy.ToLower() == "datecreated") ? this.dbSet.OrderByDescending(i => i.DateCreated) : this.dbSet.OrderBy(i => i.Title);

            items = (sortBy.ToLower() == "datecreated") ? this.dbSet.OrderByDescending(i => i.DateCreated) : this.dbSet.OrderBy(i => i.Title);
            return items.Skip(noOfRecords * currentPage).Take(noOfRecords);
        }
    }
}

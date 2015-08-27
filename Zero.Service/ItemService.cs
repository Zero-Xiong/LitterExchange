using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.Data;
using Zero.Model;

namespace Zero.Service
{
    public interface IItemService
    {
        IEnumerable<Item> GetItemsByPage(int currentPage, int noOfRecords, string sortBy, string filterBy);

        IEnumerable<Item> GetItemsByCategoryPage(string categoryId, int currentPage, int noOfRecords, string sortBy, string filterBy);

        IEnumerable<Item> GetItemsByCategoryPage(Category category, int currentPage, int noOfRecords, string sortBy, string filterBy);
    }

    public class ItemService : IItemService
    {
        private LitterDbContext context;

        public ItemService()
        {
            context = new LitterDbContext();
        }

        public ItemService(LitterDbContext _context)
        {
            context = _context;
        }

        public IEnumerable<Item> GetItemsByPage(int currentPage, int noOfRecords, string sortBy, string filterBy)
        {
            var items = (sortBy.ToLower() == "datecreated") ? context.Items.OrderByDescending(i => i.DateCreated) : context.Items.OrderBy(i => i.Title);

            return items.Skip(noOfRecords * currentPage).Take(noOfRecords).ToList();
        }

        public IEnumerable<Item> GetItemsByCategoryPage(Category category, int currentPage, int noOfRecords, string sortBy, string filterBy)
        {
            var items = context.Entry(category).Collection(i => i.Items).Query().Where(i => i.Title.Contains(filterBy) || i.Description.Contains(filterBy));

            items = (sortBy.ToLower() == "datecreated") ? items.OrderByDescending(i => i.DateCreated) : items.OrderBy(i=>i.Title);

            return items.Skip(noOfRecords * currentPage).Take(noOfRecords).ToList();
        }

        public IEnumerable<Item> GetItemsByCategoryPage(string categoryId, int currentPage, int noOfRecords, string sortBy, string filterBy)
        {
            var category = context.Categorys.Find(categoryId);

            if (category == null)
                return null;

            return this.GetItemsByCategoryPage(category, currentPage, noOfRecords, sortBy, filterBy);
        }
    }
}

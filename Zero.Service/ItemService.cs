using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.Data;
using Zero.Data.Infrastructure;
using Zero.Data.Repository;
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
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IItemRepository repository;

        public ItemService()
        {
            _UnitOfWork = new UnitOfWork();
            repository = new ItemRepository(_UnitOfWork);
        }

        public IEnumerable<Item> GetItemsByPage(int currentPage, int noOfRecords, string sortBy, string filterBy)
        {
            return repository.GetItemsByPage(currentPage, noOfRecords, sortBy, filterBy);
        }

        public IEnumerable<Item> GetItemsByCategoryPage(Category category, int currentPage, int noOfRecords, string sortBy, string filterBy)
        {
            return repository.GetItemsByCategoryPage(category, currentPage, noOfRecords, sortBy, filterBy);
        }

        public IEnumerable<Item> GetItemsByCategoryPage(string categoryId, int currentPage, int noOfRecords, string sortBy, string filterBy)
        {
            return repository.GetItemsByCategoryPage(categoryId, currentPage, noOfRecords, sortBy, filterBy);
        }
    }
}

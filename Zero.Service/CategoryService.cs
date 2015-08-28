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
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();

        IEnumerable<Category> GetCategoriesByDefaultSorting();

        Category GetCategory(string Id);

        void Save();
    }

    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly ICategoryRepository repository;

        public CategoryService()
        {
            _UnitOfWork = new UnitOfWork();
            repository = new CategoryRepository(_UnitOfWork);
        }

        public IEnumerable<Category> GetCategories()
        {
            return repository.GetAll();
        }

        public IEnumerable<Category> GetCategoriesByDefaultSorting()
        {
            return repository.GetCategoriesByDefaultSorting();
        }

        public Category GetCategory(string Id)
        {
            return repository.SingleOrDefault(Id);
        }

        public void Save()
        {
            this._UnitOfWork.Commit();
        }

    }
}

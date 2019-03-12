using System;
using CustomSite.Entities;
using CustomSite.Repositories;

namespace CustomSite.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SiteContext _context;
        private CategoryRepository _categories;
        private ProductRepository _products;

        public UnitOfWork(SiteContext context)
        {
            _context = context;
        }

        public ICategoryRepository Categories
        {
            get
            {
                return _categories ?? (_categories = new CategoryRepository(_context));
            }
        }

        public IProductRepository Products
        {
            get
            {
                return _products ?? (_products = new ProductRepository(_context));
            }
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
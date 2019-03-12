using System;
using CustomSite.Entities;
using CustomSite.Repositories;

namespace CustomSite.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SiteContext _context;

        public UnitOfWork(SiteContext context)
        {
            _context = context;
            Categories = new CategoryRepository(_context);
            Products = new ProductRepository(_context);
        }

        public ICategoryRepository Categories { get; private set; }

        public IProductRepository Products { get; private set; }

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
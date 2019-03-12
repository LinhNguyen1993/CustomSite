using System;
using CustomSite.Repositories;

namespace CustomSite.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        void SaveChange();
    }
}
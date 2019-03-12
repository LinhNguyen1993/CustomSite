using CustomSite.Core;
using CustomSite.Entities;

namespace CustomSite.Repositories
{
    public class ProductRepository : EntityBaseRepository<Product>, IProductRepository
    {
        public ProductRepository(SiteContext context) : base(context)
        {

        }
    }
}
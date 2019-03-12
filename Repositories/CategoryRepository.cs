using CustomSite.Core;
using CustomSite.Entities;

namespace CustomSite.Repositories
{
    public class CategoryRepository : EntityBaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(SiteContext context) : base(context)
        {

        }
    }
}
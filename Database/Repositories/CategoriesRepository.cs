using Domain.Models;
using Database.Abstract;

namespace Database.Repositories
{
    public class CategoriesRepository : Repository<Category>, ICategoriesRepository
    {
        public CategoriesRepository(AdminDbContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<Category>> GetRootCategoriesAsync()
        {
            return await this.FindAsync(category => category.Parent == null);
        }

        public async Task<IEnumerable<Category>> GetCategoriesByParentAsync(Category parent)
        {
            return await this.FindAsync(category => category.Parent == parent);
        }
    }
}

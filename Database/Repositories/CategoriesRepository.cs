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

        public async Task<IEnumerable<Category>> GetCategoriesByParentIdAsync(int parent)
        {
            return await this.FindAsync(category => category.Parent != null && category.Parent.Id == parent);
        }
    }
}

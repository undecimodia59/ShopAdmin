using Domain.Models;

namespace Database.Abstract
{
    public interface ICategoriesRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetRootCategoriesAsync();
        Task<IEnumerable<Category>> GetCategoriesByParentAsync(Category parent);
    }
}

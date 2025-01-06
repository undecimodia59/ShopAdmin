using Domain.Models;
using Database.Abstract;

namespace Database.Repositories
{
    public class ItemsRepository : Repository<Item>, IItemsRepository
    {
        public ItemsRepository(AdminDbContext dbContext) : base(dbContext) { }
    }
}

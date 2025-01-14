using Domain.Models;
using Database.Abstract;

namespace Database.Repositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(AdminDbContext dbContext) : base(dbContext) { }
        public async Task<Cart> AddItem(long userId, Item item)
        {
            // HOW I CAN DO THIS????????
            return null;
        }
    }
}

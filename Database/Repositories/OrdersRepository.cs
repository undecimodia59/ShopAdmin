using Domain.Models;
using Database.Abstract;

namespace Database.Repositories
{
    public class OrdersRepository : Repository<Order>, IOrdersRepository
    {
        public OrdersRepository(AdminDbContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<Order>> GetUserOrdersByUserIdAsync(long userId)
        {
            return await this.FindAsync(order => order.Client.UserId == userId);
        }
    }
}

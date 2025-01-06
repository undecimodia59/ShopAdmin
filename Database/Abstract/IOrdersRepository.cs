using Domain.Models;

namespace Database.Abstract
{
    public interface IOrdersRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetUserOrdersByUserIdAsync(long userId);
    }
}

using Domain.Models;

namespace Database.Abstract
{
    public interface ICartRepository : IRepository<Cart>
    {
        public Task<Cart> AddItem(long userId, Item item);
    }
}

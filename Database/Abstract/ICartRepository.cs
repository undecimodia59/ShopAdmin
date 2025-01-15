using Domain.Models;

namespace Database.Abstract
{
    public interface ICartRepository : IRepository<Cart>
    {
        public Task<Cart> AddItem(long userId, Item item);
        public Task<Cart> RemoveItem(long userId, int itemId);
        public Task<Cart> ClearCart(long userId);
    }
}

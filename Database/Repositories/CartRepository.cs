using Domain.Models;
using Database.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(AdminDbContext dbContext) : base(dbContext) { }
        public async Task<Cart> AddItem(long userId, Item item)
        {
           var userCart = await this.FindSingleOrThrowAsync(c => c.Owner.UserId == userId);
           if (userCart.CartItems.Any(ci => ci.ItemId == item.Id))
           {
               // If item already in cart, we make ci.Quantity += 1;
               userCart.CartItems.Single(ci => ci.ItemId == item.Id).Quantity++;
           }
           else
           {
               // If item not in cart, we add it
               userCart.CartItems.Add(new CartItem { ItemId = item.Id, Quantity = 1, ItemPrice = item.Price});
           }
           
           return userCart;
        }

        public async Task<Cart> RemoveItem(long userId, int itemId)
        {
           var userCart = await this.FindSingleOrThrowAsync(c => c.Owner.UserId == userId);
           userCart.CartItems.Remove(userCart.CartItems.Single(ci => ci.ItemId == itemId));
           return userCart;
        }
        
        public async Task<Cart> ClearCart(long userId)
        {
            var userCart = await this._dbSet.SingleAsync(c => c.Owner.UserId == userId);
            userCart.CartItems.Clear();
            
            return userCart;
        }
    }
}

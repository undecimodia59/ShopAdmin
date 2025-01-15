using Domain.Models;

namespace Services.Abstract
{
    interface IShopService
    {
        // Client
        public Task<Client> RegisterClient(long userId, string? username);
        public Task<Client> GetClient(long userId);
        public Task UpdateClientUsername(long userId, string? username);
        public Task<IEnumerable<Order>> GetClientOrders(long userId);
        public Task<IEnumerable<CartItem>> GetClientCartItems(long userId);
        public Task<IEnumerable<long>> GetAllClientsUserId();

        // Items
        public Task<Item> GetItemById(int id);
        public Task CreateItem(Item item);
        
        // Categories
        public Task<IEnumerable<Category>> GetRootCategories();
        public Task<IEnumerable<Category>> GetSubCategories(int categoryId);
        public Task<IEnumerable<Item>> GetCategoryItems(int categoryId);
        public Task CreateCategory(Category category);
        

        // Carts
        public Task<Cart> AddItemToCart(long userId, int itemId);
        public Task<Cart> GetClientCart(long userId);
        public Task ClearCart(long userId);
        public Task<Cart> RemoveItemFromCart(long userId, int cartItemId);

        // Orders
        public Task<Order> CreateOrder(long userId, string deliveryAddress);
        public Task<Order> UpdateOrderStatus(int orderId, OrderStatus newStatus);
        public Task<Order> GetOrder(int orderId);
    }
}

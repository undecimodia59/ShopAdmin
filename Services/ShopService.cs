using Services.Abstract;
using Database;
using Domain.Models;

namespace Services
{
    public class ShopService(UnitOfWork unitOfWork) : IShopService
    {
        // Client
        public async Task<Client> RegisterClient(long userId, string? username)
        {
            Client client = new Client
            {
                UserId = userId,
                Username = username,
                DateJoined = this.CurrentDateTime(),
            };
            await unitOfWork.Clients.AddAsync(client);
            await unitOfWork.CommitAsync();

            return client;
        }

        public async Task<Client> GetClient(long userId)
        {
            return await unitOfWork.Clients.GetByUserIdOrThrow(userId);
        }

        public async Task UpdateClientUsername(long userId, string? username)
        {
            await unitOfWork.Clients.UpdateUsernameAsync(userId, username);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Order>> GetClientOrders(long userId)
        {
            return await unitOfWork.Orders.FindAsync(o => o.Owner.UserId == userId);
        }

        public async Task<IEnumerable<CartItem>> GetClientCartItems(long userId)
        {
            var cart = await unitOfWork.Cart.FindSingleOrThrowAsync(c => c.Owner.UserId == userId);
            return cart.CartItems;
        }

        public async Task<IEnumerable<long>> GetAllClientsUserId()
        {
            return (await unitOfWork.Clients.GetAllAsync()).Select(c => c.UserId);
        }


        // Items
        public async Task<Item> GetItemById(int id)
        {
            return await unitOfWork.Items.FindSingleOrThrowAsync(i => i.Id == id);
        }

        public async Task CreateItem(Item item)
        {
            await unitOfWork.Items.AddAsync(item);
            await unitOfWork.CommitAsync();
        }

        // Categories
        public async Task<IEnumerable<Category>> GetRootCategories()
        {
            return await unitOfWork.Categories.GetRootCategoriesAsync();
        }

        public async Task<IEnumerable<Category>> GetSubCategories(int categoryId)
        {
            return await unitOfWork.Categories.GetCategoriesByParentIdAsync(categoryId);
        }

        public async Task<IEnumerable<Item>> GetCategoryItems(int categoryId)
        {
            return await unitOfWork.Items.FindAsync(i => i.Category.Id == categoryId);
        }

        public async Task CreateCategory(Category category)
        {
            await unitOfWork.Categories.AddAsync(category);
            await unitOfWork.CommitAsync();
        }

        // Carts
        public async Task<Cart> AddItemToCart(long userId, int itemId)
        {
            var itemToAdd = await this.GetItemById(itemId);
            var cart = await unitOfWork.Cart.AddItem(userId, itemToAdd);
            await unitOfWork.CommitAsync();

            return cart;
        }

        public async Task<Cart> GetClientCart(long userId)
        {
            return (await unitOfWork.Clients.FindSingleOrThrowAsync(user => user.UserId == userId)).Cart;
        }

        public async Task ClearCart(long userId)
        {
            await unitOfWork.Cart.ClearCart(userId);
            await unitOfWork.CommitAsync();
        }

        public async Task<Cart> RemoveItemFromCart(long userId, int itemId)
        {
            var cart = await unitOfWork.Cart.RemoveItem(userId, itemId);
            await unitOfWork.CommitAsync();
            return cart;
        }


        // Orders
        public async Task<Order> CreateOrder(long userId, string deliveryAddress)
        {
            var client = await this.GetClient(userId);
            var cart = client.Cart;
            var orderItems = cart.CartItems.Select(ci => ci.ToOrderItem());

            var order = new Order
            {
                OrderDate = this.CurrentDateTime(),
                OrderStatus = OrderStatus.Accepted,
                OrderItems = orderItems.ToList(),
                Owner = client,
                Address = deliveryAddress,
            };
            await unitOfWork.Orders.AddAsync(order);
            await unitOfWork.CommitAsync();

            return order;
        }

        public async Task<Order> UpdateOrderStatus(int orderId, OrderStatus newStatus)
        {
            var order = await unitOfWork.Orders.FindSingleOrThrowAsync(o => o.Id == orderId);
            order.OrderStatus = newStatus;
            await unitOfWork.CommitAsync();

            return order;
        }

        public async Task<Order> GetOrder(int orderId)
        {
            return await unitOfWork.Orders.FindSingleOrThrowAsync(o => o.Id == orderId);
        }

        private DateTime CurrentDateTime()
        {
            return DateTime.UtcNow.AddHours(2);
        }
    }
}
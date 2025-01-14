using Services.Abstract;
using Database;
using Domain.Models;

namespace Services
{
    public class ShopService : IShopService
    {
        private readonly UnitOfWork _unitOfWork;

        public ShopService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Client
        public async Task<Client> RegisterClient(long userId, string? username)
        {
            var utcNowPlus2 = DateTime.UtcNow.AddHours(2);
            Client client = new Client { UserId = userId, Username = username, DateJoined = utcNowPlus2 };
            await this._unitOfWork.Clients.AddAsync(client);
            await this._unitOfWork.CommitAsync();

            return client;
        }

        public async Task<Client> GetClient(long userId)
        {
            return await this._unitOfWork.Clients.GetByUserIdOrThrow(userId);
        }

        public async Task UpdateClientUsername(long userId, string? username)
        {
            await this._unitOfWork.Clients.UpdateUsernameAsync(userId, username);
            await this._unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Order>> GetClientOrders(long userId)
        {
            return await this._unitOfWork.Orders.FindAsync(o => o.Client.UserId == userId);
        }

        public async Task<IEnumerable<CartItem>> GetClientCartItems(long userId)
        {
            var cart = await this._unitOfWork.Cart.FindSingleOrThrowAsync(c => c.Client.UserId == userId);
            return cart.CartItems;
        }

        public async Task<IEnumerable<long>> GetAllClientsUserId()
        {
            return (await this._unitOfWork.Clients.GetAllAsync()).Select(c => c.UserId);
        }


        // Items
        public async Task<Item> GetItemById(int id)
        {
            return await this._unitOfWork.Items.FindSingleOrThrowAsync(i => i.Id == id);
        }


        // Carts
        public async Task<Cart> AddItemToCart(long userId, int itemId)
        {
            var cart = await this._unitOfWork.Cart.FindSingleOrThrowAsync(c => c.Client.UserId == userId);
            var itemToAdd = await this.GetItemById(itemId);
            // TODO: Check CartRepository.AddItem
            return null;
        }

        public async Task<Cart> GetClientCart(long userId)
        {
            throw new NotImplementedException();
        }

        public async Task ClearCart(long userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Cart> RemoveItemFromCart(long userId, int cartItemId)
        {
            throw new NotImplementedException();
        }


        // Orders
        public async Task<Order> CreateOrder(long userId, string deliveryAddress)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> UpdateOrderStatus(int orderId, string newStatus)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetOrder(int orderId)
        {
            throw new NotImplementedException();
        }

    }

}

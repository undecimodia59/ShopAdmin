using Database.Abstract;

namespace Database
{
    public class UnitOfWork
    {
        private readonly AdminDbContext _dbContext;

        public IOrdersRepository Orders { get; }
        public IClientsRepository Clients { get; }
        public IItemsRepository Items { get; }
        public IUsersRepository Users { get; }
        public ICategoriesRepository Categories { get; }
        public ICartRepository Cart { get; }

        public UnitOfWork(AdminDbContext dbContext,
                          IOrdersRepository orders,
                          IClientsRepository clients,
                          IItemsRepository items,
                          IUsersRepository users,
                          ICategoriesRepository categories,
                          ICartRepository cart)
        {
            _dbContext = dbContext;
            Orders = orders;
            Clients = clients;
            Items = items;
            Users = users;
            Categories = categories;
            Cart = cart;
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task Dispose()
        {
            await _dbContext.DisposeAsync();
        }
    }
}

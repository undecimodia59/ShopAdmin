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

        public UnitOfWork(AdminDbContext dbContext,
                          IOrdersRepository orders,
                          IClientsRepository clients,
                          IItemsRepository items,
                          IUsersRepository users,
                          ICategoriesRepository categories)
        {
            _dbContext = dbContext;
            Orders = orders;
            Clients = clients;
            Items = items;
            Users = users;
            Categories = categories;
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

using Domain.Models;
using Database.Abstract;
using Database.Exceptions;

namespace Database.Repositories
{
    public class ClientRepository : Repository<Client>, IClientsRepository
    {
        public ClientRepository(AdminDbContext adminDbContext) : base(adminDbContext) { }

        public async Task<Client?> GetByUserId(long userId)
        {
            return await this.FindSingleAsync(c => c.UserId == userId);
        }

        public async Task<Client> GetByUserIdOrThrow(long userId)
        {
            return await this.FindSingleOrThrowAsync(c => c.UserId == userId);
        }

        public async Task UpdateUsernameAsync(long userId, string? newUsername)
        {
            var user = await GetByUserIdOrThrow(userId);
            user.Username = newUsername;
            this.Update(user);
        }

        public async Task AddUser(Client entity)
        {
            // Check if userId already exists
            if (GetByUserId(entity.UserId) != null)
            {
                throw new AlreadyExistsException();
            }

            await this.AddAsync(entity);
        }
    }
}

using Domain.Models;
using Database.Abstract;

namespace Database.Repositories
{
    public class ClientRepository : Repository<Client>, IClientsRepository
    {
        public ClientRepository(AdminDbContext adminDbContext) : base(adminDbContext) { }

        public async Task<Client?> GetByUserId(long userId)
        {
            return await this.FindSingleAsync(c => c.UserId == userId);
        }

        public async Task UpdateUsernameAsync(long userId, string newUsername)
        {
            // Maybe move this logic to this.GetOrThrow?
            var user = await this.GetByUserId(userId);
            if (user == null)
            {
                throw new Exception("User not found!");
            }
            user.Username = newUsername;
            this.Update(user);
        }
    }
}

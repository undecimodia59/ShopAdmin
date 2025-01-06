using Domain.Models;

namespace Database.Abstract
{
    public interface IClientsRepository : IRepository<Client>
    {
        Task<Client?> GetByUserId(long userId);
        Task UpdateUsernameAsync(long userId, string newUsername);
    }
}

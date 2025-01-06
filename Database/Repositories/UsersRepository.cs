using Domain.Models;
using Database.Abstract;

namespace Database.Repositories
{
    public class UsersRepository : Repository<User>, IUsersRepository
    {
        public UsersRepository(AdminDbContext dbContext) : base(dbContext) { }
    }
}

using Web1xbet.Entities;

namespace Web1xbet.Infrastructure.Repositories
{
    public class UserRepository : EntityBaseRepository<User>, IUserRepository
    {
        public UserRepository(BetContext context)
            : base(context)
        { }
    }
}

using Web1xbet.Entities;

namespace Web1xbet.Infrastructure.Repositories
{
    public class BetRepository : EntityBaseRepository<Bet>, IBetRepository
    {
        public BetRepository(BetContext context)
            : base(context)
        { }
    }
}

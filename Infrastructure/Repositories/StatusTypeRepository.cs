using Web1xbet.Entities;

namespace Web1xbet.Infrastructure.Repositories
{
    public class StatusTypeRepository : EntityBaseRepository<StatusType>, IStatusTypeRepository
    {
        public StatusTypeRepository(BetContext context)
            : base(context)
        { }
    }
}
using Web1xbet.Entities;

namespace Web1xbet.Infrastructure.Repositories
{
    public class EventRepository : EntityBaseRepository<Event>, IEventRepository
    {
        public EventRepository(BetContext context)
            : base(context)
        { }
    }
}

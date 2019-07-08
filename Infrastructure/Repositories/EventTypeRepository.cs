using Web1xbet.Entities;

namespace Web1xbet.Infrastructure.Repositories
{
    public class EventTypeRepository : EntityBaseRepository<EventType>, IEventTypeRepository
    {
        public EventTypeRepository(BetContext context)
            : base(context)
        { }
    }
}

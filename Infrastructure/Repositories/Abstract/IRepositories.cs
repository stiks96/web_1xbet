using Web1xbet.Entities;

namespace Web1xbet.Infrastructure.Repositories
{
    public interface IBetRepository : IEntityBaseRepository<Bet> { }
    public interface IUserRepository : IEntityBaseRepository<User> { }
    public interface IEventRepository : IEntityBaseRepository<Event> { }
    public interface IEventTypeRepository : IEntityBaseRepository<EventType> { }
    public interface IStatusTypeRepository : IEntityBaseRepository<StatusType> { }
}

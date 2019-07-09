using System.Collections.Generic;
using Web1xbet.Entities;

namespace Web1xbet.Infrastructure.Repositories
{
    public interface IBetRepository : IEntityBaseRepository<Bet> 
    {
        List<Bet> GetAllBet(User user);
        bool CancelBet(int id);
        Bet ChangeBet(Bet newBet);
    }
    public interface IUserRepository : IEntityBaseRepository<User> 
    {
        User GetUser(string username);
        User GetUser(string username, string password);
        bool RemoveUser(string username);
        User UpdateBalance(string username, double balance);
        User ChangeStatus(string username, StatusType status);
    }
    public interface IEventRepository : IEntityBaseRepository<Event> { }
    public interface IEventTypeRepository : IEntityBaseRepository<EventType> { }
    public interface IStatusTypeRepository : IEntityBaseRepository<StatusType> { }
}

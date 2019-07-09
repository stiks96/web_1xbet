using System;
using System.Linq;
using Web1xbet.Entities;

namespace Web1xbet.Infrastructure.Repositories
{
    public class UserRepository : EntityBaseRepository<User>, IUserRepository
    {
        public UserRepository(BetContext context)
            : base(context)
        { }

        public User GetUser(string username)
        {
            try
            {
                var result = base.FindBy(user => user.Username == username).ToList();
                return result.First();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public User GetUser(string username, string password)
        {
            try
            {
                var result = base.FindBy(user => user.Username == username && user.Password == password).ToList();
                return result.First();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool RemoveUser(string username)
        {
            try
            {
                var result = base.FindBy(user => user.Username == username).ToList().First();
                base.Delete(result);
                base.Commit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public User UpdateBalance(string username, double balance)
        {
            try
            {
                var result = base.FindBy(user => user.Username == username).ToList().First();
                result.Balance = balance;
                base.Edit(result);
                base.Commit();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public User ChangeStatus(string username, StatusType status)
        {
            try
            {
                var result = base.FindBy(user => user.Username == username).ToList().First();
                result.Status = status;
                result.StatusId = status.Id;
                base.Edit(result);
                base.Commit();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Web1xbet.Entities;

namespace Web1xbet.Infrastructure.Repositories
{
    public class UserRepository : EntityBaseRepository<User>, IUserRepository
    {
        public UserRepository(BetContext context)
            : base(context)
        { }

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
    }
}

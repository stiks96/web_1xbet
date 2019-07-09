using System;
using System.Collections.Generic;
using System.Linq;
using Web1xbet.Entities;

namespace Web1xbet.Infrastructure.Repositories
{
    public class BetRepository : EntityBaseRepository<Bet>, IBetRepository
    {
        public BetRepository(BetContext context)
            : base(context)
        { }

        public List<Bet> GetAllBet(User user)
        {
            try
            {
                var result = base.FindBy(bet => bet.UserId == user.Id).ToList();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool CancelBet(int id)
        {
            try
            {
                var result = base.FindBy(bet => bet.Id == id).ToList().First();
                base.Delete(result);
                base.Commit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Bet ChangeBet(Bet newBet)
        {
            try
            {
                var result = base.FindBy(bet => bet.Id == newBet.Id).ToList().First();
                base.Edit(newBet);
                base.Commit();
                return newBet;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

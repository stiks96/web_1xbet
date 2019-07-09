using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Web1xbet.Entities;
using Web1xbet.Infrastructure.Repositories;

namespace Web1xbet.Controllers
{
    [Route("api/[controller]")]
    public class BetController : Controller
    {
        private readonly IUserRepository usersRepository;
        private readonly IBetRepository betRepository;

        public BetController(IUserRepository usersRepository, IBetRepository betRepository)
        {
            this.usersRepository = usersRepository;
            this.betRepository = betRepository;
        }

        [HttpGet("[action]")]
        public List<Bet> GetAllBet([FromQuery(Name = "username")] string username)
        {
            var user = usersRepository.GetUser(username);
            return betRepository.GetAllBet(user);
        }

        [HttpDelete("[action]")]
        public bool CancelBet([FromQuery(Name = "id")] int id)
        {
            return betRepository.CancelBet(id);
        }

        // TODO Add change bet and add bet
    }
}

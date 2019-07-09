using Microsoft.AspNetCore.Mvc;
using Web1xbet.Entities;
using Web1xbet.Infrastructure.Repositories;

namespace Web1xbet.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository usersRepository;
        private readonly IStatusTypeRepository statusTypeRepository;

        public UsersController(IUserRepository usersRepository, IStatusTypeRepository statusTypeRepository)
        {
            this.usersRepository = usersRepository;
            this.statusTypeRepository = statusTypeRepository;
        }

        [HttpGet("[action]")]
        public User GetUser([FromQuery(Name = "username")] string username,
            [FromQuery(Name = "password")] string password)
        {
            return usersRepository.GetUser(username, password);
        }

        [HttpDelete("[action]")]
        public bool DeleteUser([FromQuery(Name = "username")] string username)
        {
            return usersRepository.RemoveUser(username);
        }

        [HttpGet("[action]")]
        public User ChangeBalance([FromQuery(Name = "username")] string username,
            [FromQuery(Name = "balance")] double balance)
        {
            return usersRepository.UpdateBalance(username, balance);
        }

        [HttpGet("[action]")]
        public User ChangeStatus([FromQuery(Name = "username")] string username,
            [FromQuery(Name = "status")] int statusId)
        {
            var status = statusTypeRepository.GetSingle(statusId);
            return usersRepository.ChangeStatus(username, status);
        }

        [HttpGet("[action]")]
        public bool InitEFModel()
        {
            // инициализация
            var result = usersRepository.GetSingle(1);
            return true;
        }
    }
}

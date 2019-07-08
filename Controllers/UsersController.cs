using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Web1xbet.Entities;
using Web1xbet.Infrastructure.Repositories;

namespace Web1xbet.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository usersRepository;

        public UsersController(IUserRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        [HttpGet("[action]")]
        public User GetUser([FromQuery(Name = "username")] string username,
            [FromQuery(Name = "password")] string password)
        {
            return usersRepository.GetUser(username, password);
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

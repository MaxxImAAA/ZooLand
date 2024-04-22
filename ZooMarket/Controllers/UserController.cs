using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZooMarket.Data;
using ZooMarket.Models;

namespace ZooMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        [HttpPost("Adduser")]
        public ActionResult<string> AddUser(string Name, string Email)
        {
            var user = new User
            {
                Name = Name,
                Email = Email,
                Order = new Order()

            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return "Пользователь добавлен";
        }
    }
}

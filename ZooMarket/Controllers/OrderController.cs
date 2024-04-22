using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooMarket.Data;
using ZooMarket.Dtos.OrderDtos;
using ZooMarket.Models;

namespace ZooMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private ApplicationDbContext _context;
        public OrderController(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        [HttpPost("AddOrder")]
        public ActionResult<string> AddOrder(int PetId, int UserId)
        {
            var pet = _context.Pets.FirstOrDefault(x => x.Id == PetId);
            var user = _context.Users.Include(x => x.Order).FirstOrDefault(x => x.Id == UserId);

            var petorder = new PetOrder()
            {
                Order = user.Order,
                Pet = pet
            };

            _context.PetOrders.Add(petorder);
            _context.SaveChanges();

            return "Добавлено в заказ пользователя";
        }

        [HttpGet("GetOrderById")]
        public ActionResult<List<OrderPetDto>> GetUsersOrderByUserId(int UserId)
        {
            var user = _context.Users.Include(x => x.Order).FirstOrDefault(x => x.Id == UserId);

            var petorders = _context.PetOrders.Where(x=>x.Order == user.Order).Select(x=>x.PetId).ToList();

            var pets = new List<Pet>();

            foreach(var p in petorders)
            {
                pets.Add(_context.Pets.FirstOrDefault(x => x.Id == p));
            }


            var petsdto = pets.Select(x => new OrderPetDto { Name = x.Name, Description = x.Description, TypePet = x.TypePet }).ToList();

            return petsdto;
            

        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZooMarket.Data;
using ZooMarket.Dtos.PetDtos;
using ZooMarket.Models;

namespace ZooMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PetController(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        [HttpPost("AddPet")]
        public ActionResult<string> AddPet(CreatePetDto createPetDto)
        {
            var pet = new Pet
            {
                Name = createPetDto.Name,
                Description = createPetDto.Description,
                Price = createPetDto.Price,
                TypePet = createPetDto.TypePet,
            };

            _context.Pets.Add(pet);
            _context.SaveChanges();

            return "Животное добавлено";
        }

        [HttpGet("Getpets")]
        public ActionResult<List<PetDto>> GetPets()
        {
            var pets = _context.Pets.Select(x => new PetDto { Description = x.Description, Id = x.Id, Name = x.Name, Price = x.Price, TypePet = x.TypePet }).ToList();

            return pets;
        }
        
    }
}

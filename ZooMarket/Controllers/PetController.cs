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

        [HttpPut("UpdatePet")]
        public ActionResult<string> UpdatePet(CreatePetDto updatepet, int PetId)
        {
            var pet = _context.Pets.FirstOrDefault(x => x.Id == PetId);

            pet.Name = updatepet.Name;
            pet.Description = updatepet.Description;
            pet.Price = updatepet.Price;
            pet.TypePet = updatepet.TypePet;

            _context.Pets.Update(pet);
            _context.SaveChanges();

            return "Животное обновлено";

        }

        [HttpDelete("PetRemove")]
        public ActionResult<string> DeletePet(int PetId)
        {
            var pet = _context.Pets.FirstOrDefault(x => x.Id == PetId);

            _context.Pets.Remove(pet);
            _context.SaveChanges();

            return "Животное удалено";
        }

        [HttpGet("GetPetById")]
        public ActionResult<PetDto> GetPetById(int PetId)
        {
            var pet = _context.Pets.Where(x=>x.Id == PetId)
                                    .Select(x=> new PetDto { Id = x.Id, Description = x.Description, Name = x.Name, Price = x.Price, TypePet = x.TypePet})
                                    .FirstOrDefault();

            

            return pet;

        }

    }
}

namespace ZooMarket.Dtos.PetDtos
{
    public class CreatePetDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string TypePet { get; set; }
        public int Price { get; set; }
    }
}

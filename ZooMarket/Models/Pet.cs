namespace ZooMarket.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TypePet { get;set; }
        public int Price { get; set; }

        public List<PetOrder> PetOrders { get; set; }
        
    }
}

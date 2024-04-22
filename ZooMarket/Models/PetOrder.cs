namespace ZooMarket.Models
{
    public class PetOrder
    {
        public int Id { get; set; }

        public Pet Pet { get; set; }
        public int PetId { get; set; }

        public Order Order { get; set; }
        public int OrderId { get; set; }
    }
}

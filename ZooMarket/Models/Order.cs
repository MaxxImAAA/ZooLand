namespace ZooMarket.Models
{
    public class Order
    {
        public int Id { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
       
        public List<PetOrder> PetOrders { get; set; }
    }
}

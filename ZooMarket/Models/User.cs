namespace ZooMarket.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }


        public Order Order { get; set; }
        
    }
}

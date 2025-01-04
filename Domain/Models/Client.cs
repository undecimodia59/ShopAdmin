namespace Domain.Models
{
    public class Client
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public long UserId { get; set; }
        public DateTime DateJoined { get; set; }
        public int TotalSpent { get; set; }
        public int TotalOrders { get; set; }
    }
}

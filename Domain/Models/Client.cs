using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Client
    {
        [Key]
        public long UserId { get; set; }
        public string? Username { get; set; }
        public Cart Cart { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public DateTime DateJoined { get; set; }
    }
}

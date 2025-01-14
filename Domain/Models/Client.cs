using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Client
    {
        [Key]
        public long UserId { get; set; }
        public string? Username { get; set; }
        public DateTime DateJoined { get; set; }
    }
}

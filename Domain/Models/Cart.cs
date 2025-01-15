namespace Domain.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public Client Owner { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}

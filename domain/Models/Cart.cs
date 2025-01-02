namespace admin_panel.Data.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}

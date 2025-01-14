namespace Domain.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int ItemPrice { get; set; }
        public int Quantity { get; set; }
    }
}

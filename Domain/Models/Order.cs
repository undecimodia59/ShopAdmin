namespace Domain.Models
{
    public enum OrderStatus
    {
        Accepted,
        Sent,
        Support,
    }

    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public Client Client { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public int Total()
        {
            return this.OrderItems.Aggregate(0, (sum, item) => sum + item.ItemPrice * item.Quantity);
        }
    }
}

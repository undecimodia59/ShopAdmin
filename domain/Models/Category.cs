namespace admin_panel.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category? Parent { get; set; }
    }
}

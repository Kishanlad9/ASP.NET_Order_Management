namespace Order_management.DTOs.Category
{
    public class CategoryResponsedto
    {
        public int Id { get; set; }
        public string categoryName { get; set; }=string.Empty;
        public string? Description { get; set; }
        public DateTime? createdAt { get; set; }
    }
}

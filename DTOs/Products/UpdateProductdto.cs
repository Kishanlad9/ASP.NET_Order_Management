using System.ComponentModel.DataAnnotations;

namespace Order_management.DTOs.Products
{
    public class UpdateProductdto
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public int Category_Id { get; set; }

    }
}

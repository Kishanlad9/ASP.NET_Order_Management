using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Order_management.Models
{
    [Table("products")]
    public class Products
    {
        
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(500)]
        [Column("description")]
        public string Description { get; set; } = string.Empty;

        [Column("price", TypeName = "decimal(18,2)")]
        [Required]
        public decimal Price { get; set; }

        [Required]
        [Column("stock")]
        public int Stock { get; set; }

        public bool IsDeleted { get; set;} = false;

        public int Category_Id { get; set;}
        [ForeignKey("Category_Id")]

        public Category Category { get; set; }

        public DateTime createdAt { get; set; } = DateTime.UtcNow;





    }
}

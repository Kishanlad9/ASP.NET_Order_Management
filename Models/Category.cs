using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Order_management.Models
{
    [Table("category")]
    public class Category

    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("categoryname")]
        [MaxLength(100)]
        public string categoryName { get; set; } = string.Empty;

        [Required]
        [MaxLength(500)]
        public string?Description { get; set;}

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool isDeleted { get; set; } = false;


    }
}

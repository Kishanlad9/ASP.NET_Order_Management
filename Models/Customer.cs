using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Order_management.Models
{
    [Table("customers")]
    [Index(nameof(Email), IsUnique = true)]
    public class Customer
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        public String Name { get; set; } = string.Empty;

        [Column("contact")]
        [StringLength(10)]
        [RegularExpression(@"^[0-9]{10}$")]
        public String Contact { get; set; } = string.Empty;

        [Column("address")]
        [Required]
        [StringLength(100)]
        public String Address { get; set; } = string.Empty;

        [Column("email")]
        [Required]
        [EmailAddress]
        public String Email { get; set; } = string.Empty;

        [Column("password_hash")]
        public string PasswordHash { get; set; } = string.Empty;

        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}

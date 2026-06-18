using System.ComponentModel.DataAnnotations;

namespace Order_management.DTOs.Category
{
    public class CreateCategorydto
    {

        [Required(ErrorMessage ="Category name is Required")]
        [MaxLength(100)]
        public string CategoryName { get; set; }=string.Empty;
        [MaxLength(500)]
        public string? Description { get; set; }
    }
}

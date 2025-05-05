using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebapiProject.Models
{
    public class Product
    {
        [Key]
        public string ProductId { get; set; } 

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(100, ErrorMessage = "Product name cannot be longer than 100 characters.")]
        public string ProductName { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        public string Description { get; set; }

        [StringLength(500, ErrorMessage = " less than 500 characters.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Available quantity is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Available quantity must be a non-negative number.")]
        public long AvailableQuantity { get; set; }

        [Required(ErrorMessage = "Unit price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Unit price must be a positive number.")]
        public decimal UnitPrice { get; set; }

        [ForeignKey("Supplier")]
        [Required(ErrorMessage = "Supplier ID is required.")]
        public int SupplierId { get; set; }

        public string Image { get; set; }

        // Navigation property
        //public virtual Supplier Supplier { get; set; }
    }
}

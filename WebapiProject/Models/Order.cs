using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebapiProject.Models
{
    public class Order
    {
        [Key] //data annotations
        [JsonIgnore]
        public int OrderId { get; set; } // Auto-generated ID

        [ForeignKey("Product")]
        [Required(ErrorMessage = "Product ID is required.")]
        public string ProductId { get; set; } // Foreign key from Product table
        [JsonIgnore]
        [ForeignKey("User")]
        [Required(ErrorMessage = "User ID is required.")]
        public int UserId { get; set; } // Foreign key from User table

        [Required(ErrorMessage = "Ordered quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Ordered quantity must be at least 1.")]
        public int OrderedQuantity { get; set; } // Quantity ordered

        [JsonIgnore]
        [StringLength(50, ErrorMessage = "Status cannot be longer than 50 characters.")]
        public string Status { get; set; } = "placed";// Order status
        [JsonIgnore]
        [Required]
        public DateTime OrderDate { get; set; } // Auto-generated order date

        // Navigation properties
        //public virtual Product Product { get; set; }
        //public virtual User User { get; set; }
    }
}

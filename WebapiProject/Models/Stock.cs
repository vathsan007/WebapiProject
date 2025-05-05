using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebapiProject.Models
{
    public class Stock
    {
        [Key]
        [JsonIgnore]
        public int StockId { get; set; } // Auto-generated ID

        [ForeignKey("Product")]
        public string ProductId { get; set; } // Foreign key from Product table

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity added must be a non-negative number.")]
        public long QuantityAdded { get; set; } // Quantity added by admin

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity decreased must be a non-negative number.")]
        public int QuantityDecreased { get; set; } // Quantity decreased (order placed or admin update)

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Total stock must be a non-negative number.")]
        public long TotalStock { get; set; } // Current total stock

        [Required]
        public DateTime Date { get; set; } // Date of stock update

        // Navigation property
        //public virtual Product Product { get; set; }
    }
}

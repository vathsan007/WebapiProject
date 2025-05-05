using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebapiProject.Models
{
    public class Report
    {
        [Key]
        [JsonIgnore]
        public int ReportId { get; set; } // Auto-generated ID

        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required.")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Report type is required.")]
        [StringLength(50, ErrorMessage = "Report type cannot be longer than 50 characters.")]
        public string ReportType { get; set; } // Inventory, Order, Sales

        // Navigation properties for related data
        //public virtual ICollection<Order> Orders { get; set; }
        //public virtual ICollection<Stock> Stocks { get; set; }
    }
}

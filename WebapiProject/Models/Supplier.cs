using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text.Json.Serialization;

namespace WebapiProject.Models
{
    public class Supplier
    {
        [Key]
        
        public int SupplierId { get; set; } // Auto-generated ID

        [Required(ErrorMessage = "Supplier name is required.")]
        [StringLength(100, ErrorMessage = "Supplier name cannot be longer than 100 characters.")]
        public string SupplierName { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid Phone Number.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        // Navigation property for the list of products supplied by the supplier
        //public virtual ICollection<Product> Products { get; set; } =  new List<Product>();
    }
}

using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text.Json.Serialization;

namespace WebapiProject.Models
{
    public class User
    {
        [Key]
        
        public int UserId { get; set; } // Auto-generated ID

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, ErrorMessage = "Username cannot be longer than 50 characters.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }


        

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid Phone Number.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(200, ErrorMessage = "Address cannot be longer than 200 characters.")]
        public string Address { get; set; }
       public string Role { get; set; }
        [Required(ErrorMessage = "Security question is required.")]
        [StringLength(200, ErrorMessage = "Security question cannot be longer than 200 characters.")]
        public string SecurityQuestion { get; set; }

        [Required(ErrorMessage = "Security answer is required.")]
        [StringLength(200, ErrorMessage = "Security answer cannot be longer than 200 characters.")]
        public string SecurityAnswer { get; set; }

    }
}

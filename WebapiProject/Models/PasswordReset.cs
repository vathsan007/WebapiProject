namespace WebapiProject.Models
{
    public class PasswordReset
    {
        public string Email { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public string NewPassword { get; set; }
    }
}

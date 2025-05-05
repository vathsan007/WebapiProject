namespace WebapiProject.Models
{
    

        public class UpdateUserDetail
        {
            public int UserId { get; set; }
            public string Name { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public string Role { get; set; }
            public string SecurityQuestion { get; set; }
            public string SecurityAnswer { get; set; }
        }


    
}

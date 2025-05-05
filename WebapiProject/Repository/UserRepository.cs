using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;
using WebapiProject.Models;

namespace WebapiProject.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext db;

        public UserRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        private readonly List<User> users = new List<User>();

        public int AddUser(User user)
        {
            if (user == null)
            {
                throw new System.Exception("User cannot be null.");
            }

            // Hash the password before saving
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            db.Users.Add(user);
            return db.SaveChanges();
        }

        public User GetUserById(int Id)
        {
            var user = db.Users.FirstOrDefault(x => x.UserId == Id);
            if (user == null)
            {
                throw new System.Exception("User not found.");
            }

            return user;
        }

        public User GetUserByUsername(string username)
        {

            var users = db.Users.Where(u => u.Username == username).ToList();
            if (users.Count > 1)
            {
                // Handle the case where multiple users with the same username exist
                Console.WriteLine("Warning: Multiple users found with the same username.");
            }
            return users.FirstOrDefault();
        }

        public bool ValidateUserCredentials(string username, string password)
        {
            var user = db.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                return false; // User not found
            }

            // Verify the entered password against the stored hashed password
            return BCrypt.Net.BCrypt.Verify(password, user.Password);
        }


        public void UpdateUserDetail(UpdateUserDetail dto)
        {
            var sql = "EXEC UpdateUserDetail @UserId, @Name, @Username, @Email, @Phone, @Address, @Role, @SecurityQuestion, @SecurityAnswer";
            db.Database.ExecuteSqlRaw(sql,
            new SqlParameter("@UserId", dto.UserId),
            new SqlParameter("@Name", dto.Name),
            new SqlParameter("@Username", dto.Username),
            new SqlParameter("@Email", dto.Email),
            new SqlParameter("@Phone", dto.Phone),
            new SqlParameter("@Address", dto.Address),
            new SqlParameter("@Role", dto.Role),
            new SqlParameter("@SecurityQuestion", dto.SecurityQuestion),
            new SqlParameter("@SecurityAnswer", dto.SecurityAnswer));
        }


       


        public void PasswordReset(PasswordReset dto)
        {
            // Hash the new password before updating
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);

            var sql = "EXEC ResetPassword @Email, @SecurityQuestion, @SecurityAnswer, @NewPassword";
            db.Database.ExecuteSqlRaw(sql,
            new SqlParameter("@Email", dto.Email),
            new SqlParameter("@SecurityQuestion", dto.SecurityQuestion),
            new SqlParameter("@SecurityAnswer", dto.SecurityAnswer),
            new SqlParameter("@NewPassword", hashedPassword));
        }


    }
}
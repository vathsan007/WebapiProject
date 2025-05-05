using WebapiProject.Models;

namespace WebapiProject.Repository
{
    public interface IUserRepository
    {
        int AddUser(User user);
        User GetUserByUsername(string username);

        User GetUserById(int Id);
        bool ValidateUserCredentials(string username, string password);

        void UpdateUserDetail(UpdateUserDetail dto);

        void PasswordReset(PasswordReset dto);
    }
}

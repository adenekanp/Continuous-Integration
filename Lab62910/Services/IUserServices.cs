using Lab62910.Data;
using System.Collections.Generic;
namespace Lab62910.Services
{
   

    public interface IUserService
    {
        List<User> GetUsers();
        void AddUser(User user);
        void EditUser(User updatedUser);
        void DeleteUser(int userId);
        User GetUserByNameAndEmail(string name, string email);
        User GetUserByName(string userName);
    }

}

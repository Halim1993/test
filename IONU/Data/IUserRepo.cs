using IONU.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IONU.Data
{
   public interface IUserRepo
    {
        Task AddUser(User user);
        Task<User> GetUser(int id);

        Task<List<User>> GetUsers();

        Task UpdateUser(User user);

        Task DeletUser(int id);

        Task<User> Login(Login login);

    }
}

using IONU.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IONU.Data
{
    public class MooKUser : IUserRepo
    {

        public MooKUser(ApplicationDbcontext dbContext)
        {
            _app = dbContext;
          



        }

        public ApplicationDbcontext _app { get; }

        public async Task AddUser(User user)
        {
            try
            {
                await _app.USers.AddAsync(user);

                await _app.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
         
        }

        public  async Task DeletUser(int id)
        {
            try
            {
                User user = await _app.USers.FindAsync(id);
                if (user != null)
                    _app.USers.Remove(user);

                await _app.SaveChangesAsync();


            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public async Task<User> GetUser(int id)
        {
            try
            {
                User user = await _app.USers.FindAsync(id);


                return user;

            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public async Task<List<User>> GetUsers()
        {
            try
            {
                var users = await _app.USers.ToListAsync();
                return users;

            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public async Task<User> Login(Login login)
        {
            try
            {
                User user = await _app.USers.FirstOrDefaultAsync(x => x.User_Name == login.UserName && x.Pasword == login.Password);
                return user;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public async  Task UpdateUser(User user)
        {
            try
            {
                User user1 = await _app.USers.FindAsync(user.Id);

                if (user != null)
                {


                    _app.USers.Update(user);
                    await _app.SaveChangesAsync();


                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}

using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserDAO
    {
        public static List<User> GetUsers()
        {
            var listUsers = new List<User>();
            try
            {
                using (var context = new EBookStoreContext())
                {
                    listUsers = context.Users.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listUsers;
        }

        public static User GetUserById(int UserId)
        {
            var User = new User();
            try
            {
                using (var context = new EBookStoreContext())
                {
                    User = context.Users.FirstOrDefault(x => x.UserId == UserId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return User;
        }

        public static void SaveUser(User User)
        {
            try
            {
                using (var context = new EBookStoreContext())
                {
                    context.Users.Add(User);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateUser(User User)
        {
            try
            {
                using (var context = new EBookStoreContext())
                {
                    context.Entry<User>(User).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteUser(User User)
        {
            try
            {
                using (var context = new EBookStoreContext())
                {
                    var u = context.Users.SingleOrDefault(x => x.UserId == User.UserId);
                    context.Users.Remove(u);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

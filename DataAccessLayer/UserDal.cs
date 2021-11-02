using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class UserDal
    {
        public static User GetUser(string userName, string password)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                User user = context.Users.Where(user => user.userName == userName && user.userPassword == password).FirstOrDefault();
                return user;

            }
        }

        public static User GetUser(int id)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                User user = context.Users.Where(user => user.userId == id).FirstOrDefault();
                return user;

            }
        }
    }
}

using EntityLayer;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class UserBusiness
    {
        public static User GetUser(string name, string password)
        {
            return UserDal.GetUser(name, password);
        }

        public static User GetUser(int userId)
        {
            return UserDal.GetUser(userId);
        }
    }
}

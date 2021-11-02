using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
   public class TestBusiness
    {

        public static void AddTest(Test test)
        {
            TestDal.AddTest(test);
        }
        public static void DeleteTest(Test test)
        {
            TestDal.DeleteTest(test);
        }

        public static Test GetTest(string key)
        {
            return TestDal.GetTest(key);
        }
        public static Test GetTest(int id)
        {
            return TestDal.GetTest(id);
        }
        public static List<Test> GetTestList(int id)
        {
            return TestDal.GetTestList(id);
        }
        public static List<Test> GetAllTestList()
        {
            return TestDal.GetTestList();
        }
    }
}

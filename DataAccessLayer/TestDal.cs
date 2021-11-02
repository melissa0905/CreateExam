using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class TestDal
    {
        public static void AddTest(Test test)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var addedEntity = context.Entry(test);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static void DeleteTest(Test test)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var deletedEntity = context.Entry(test);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public static Test GetTest(string key)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Tests.Where(t => t.key == key).FirstOrDefault();
            }
        }
        public static Test GetTest(int id)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Tests.Where(t => t.testId == id).FirstOrDefault();
            }
        }

        public static List<Test> GetTestList(int userId)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Tests.Where(t => t.userId == userId).ToList();
            }
        }
        public static List<Test> GetTestList()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Tests.ToList();
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using EntityLayer;
using DataAccessLayer;
namespace BusinessLogicLayer
{
    public class QuestionBusiness
    {
        public static void AddQuestion(Question question)
        {
            QuestionDal.AddQuestion(question);
        }

        public static List<Question> GetQuestions(int testid, int userId)
        {

            return QuestionDal.GetQuestions(testid, userId);
        }

        public static void SaveQuestions(Question[] questions, Test test)
        {
            foreach (Question question in questions)
            {
                question.testId = test.testId;
                AddQuestion(question);
            }
        }

        public static List<Question> GetTestQuestion(int testId)
        {
            return QuestionDal.GetTestQuestion(testId);
        }
    }
}

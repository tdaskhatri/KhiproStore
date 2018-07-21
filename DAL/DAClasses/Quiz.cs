using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eLearning.DAL.DataAccess;
using eLearning.Common.Utils;
using System.Data;

namespace eLearning.DAL.DAClasses
{
    public class Quiz
    {

        DAQuiz quiz = new DAQuiz();
        private const string MODULE_NAME = "Quiz.cs";
        Logger logger = Logger.getInstance();

        // Added by Muhammad Uzair on 17/01/2018 12:48:45 
        public DataTable GetQuizResultSchemaTable()
        {
            try
            {
                return quiz.GetQuizResultSchemaTable();
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "GetQuizResultSchemaTable", ex);
                throw ex;
            }
        }

        // Added by Muhammad Uzair on 17/01/2018 14:47:07 
        public DataTable GetAnswerPool()
        {
            try
            {
                return quiz.GetAnswerPool();
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "GetAnswerPool", ex);
                throw ex;
            }
        }

        // Added by Muhammad Uzair on 17/01/2018 12:56:46 
        public DataTable InsertUserQuizResult(DataTable dt, string ExamTemplateId, string EmiratesId, int CompanyId)
        {
            try
            {
                return quiz.InsertUserQuizResult(dt, ExamTemplateId, EmiratesId, CompanyId);
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "InsertUserQuizResult", ex);
                throw ex;
            }
        }

        public bool CheckValidEmirate(int training_request_id, string emirate_id, out string fullName)
        {
            try
            {
                return quiz.ValidateEmirateID(training_request_id, emirate_id, out fullName);
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "CheckValidEmirate", ex);
                throw ex;
            }

        }

        public DataSet GetExamTemplate(int training_request_id)
        {
            return quiz.GetExamTemplate(training_request_id);
        }
        public DataSet GetQuestions(string qids)
        {
            return this.quiz.GetQuestions(qids);
        }

    }
}

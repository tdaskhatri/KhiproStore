using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using eLearning.Common;
using System.Reflection;
using System.Collections;
using eLearning.DAL.DataAccess;
using eLearning.Common.Utils;
using System.Data.Common;

namespace eLearning.DAL.DAClasses
{
    public class ExamResult
    {

        public string CalculateResult(String request,String testTakerId)
        {

            string[] responses = request.Split('|');
            DAAnswersPool oDAAnswersPool = new DAAnswersPool();
            DataSet dsAnswers = oDAAnswersPool .GetAnswersByTestTakerId(testTakerId);
            DataTable dtAnswers = dsAnswers.Tables[0];
            StringBuilder whereClause = new StringBuilder(" WHERE TEST_TAKER_ID =" + testTakerId + " and  QUESTION_ID IN (");
            StringBuilder caseClauseForStatus  = new StringBuilder( " STATUS = CASE QUESTION_ID " );
            StringBuilder caseClauseForResponse = new StringBuilder(" SELECTED_ANSWER = CASE QUESTION_ID ");
            foreach (string response in responses)
            {
                if( string.IsNullOrEmpty(response) || response.Length <= 0)
                continue;
                string[] subResponse = response.Split('_');
                string questionId = subResponse[1];
                whereClause.Append( questionId+"," );
                
                string caseTemplate = " WHEN "+questionId+" THEN {0} ";
                string caseTemplateForResponse = " WHEN " + questionId + " THEN '{0}' ";
                int catId = int.Parse(subResponse[0]);
                if (catId.Equals((int)Enumaration.QuestionType.SingleSelection))
                {
                    CompileSingleSelectionResult(dtAnswers, caseClauseForStatus, caseClauseForResponse, subResponse, questionId, caseTemplate, caseTemplateForResponse);
                    

                }
                else if (catId.Equals((int)Enumaration.QuestionType.Categorybased))
                {
                    //TODO
                    CompileCategoryBasedResult(dtAnswers, caseClauseForStatus, caseClauseForResponse, subResponse, questionId, caseTemplate, caseTemplateForResponse);

                }
                else if (catId.Equals((int)Enumaration.QuestionType.MatchImagewithImage ) ||
                         catId.Equals((int)Enumaration.QuestionType.MatchImagewithText ) ||
                         catId.Equals((int)Enumaration.QuestionType.MapLocator) 
                        )
                {

                    CompileMatchImageWithImageAndMatchImageWithTextResult(dtAnswers, caseClauseForStatus, caseClauseForResponse, subResponse, questionId, caseTemplate, caseTemplateForResponse);
                }
                

            }
            string where = whereClause.ToString();
            where = where.Substring(0, (where.Length - 1)) + ")";
            DATestTakers oDATestTakers = new DATestTakers();
            caseClauseForStatus.Append(" END ");
            caseClauseForResponse.Append(" END ");
            DataSet ds = oDATestTakers.PostResult(testTakerId, caseClauseForStatus.ToString(), caseClauseForResponse.ToString(), where);
            if (ds != null && ds.Tables[0].Columns.Contains("STATUS"))
            {
                if (ds.Tables[0].Rows[0]["STATUS"].ToString().Equals("3"))
                {
                    return "3";
                }
                else if (ds.Tables[0].Rows[0]["STATUS"].ToString().Equals("4"))
                {
                    return "4";
                }
            }
            return string.Empty;
        }

        private static void CompileSingleSelectionResult( DataTable dtAnswers, StringBuilder caseClauseForStatus, StringBuilder caseClauseForResponse,
                                                          string[] subResponse, string questionId, string caseTemplate, string caseTemplateForResponse)
        {
            DataRow[] row = dtAnswers.Select(Entities.QuestionsPool.ID + " = " + questionId);
            string result;
            if (row[0][Entities.AnswersPool.ID].ToString().Equals(subResponse[2]))
            {

                result = ((int)Enumaration.TestTakerQuestionStatus.Right).ToString();


            }
            else
            {
                result = ((int)Enumaration.TestTakerQuestionStatus.Wrong).ToString();

            }
            caseClauseForStatus.Append( string.Format(caseTemplate, result));
            caseClauseForResponse.Append(string.Format(caseTemplateForResponse, subResponse[2]));
        }

        private static void CompileCategoryBasedResult(DataTable dtAnswers, StringBuilder caseClauseForStatus, StringBuilder caseClauseForResponse ,
                                                        string[] subResponse, string questionId, string caseTemplate, string caseTemplateForResponse)
        {
            Enumaration.TestTakerQuestionStatus status = Enumaration.TestTakerQuestionStatus.Right;
            if (subResponse[2][0].Equals(':'))
            {
                subResponse[2] = subResponse[2].Remove(0, 1);
                
            }
            else if (subResponse[2][subResponse[2].Length-1].Equals(':'))
            {
                subResponse[2] = subResponse[2].Remove(subResponse[2].Length - 1, 1);
            }
            string[] matchResponse = subResponse[2].Substring(0, subResponse[2].Length ).Split(':');
            DataRow[] rowsMatchingQuestionId = dtAnswers.Select(Entities.QuestionsPool.ID + " = " + questionId);
            DataTable dtAnswersAgainstQuestion = new DataTable();
            dtAnswersAgainstQuestion = rowsMatchingQuestionId.CopyToDataTable();
            //Check if user's answered items count is equal to total number of answers against the question
            if (matchResponse.Length == rowsMatchingQuestionId.Length)
            {
                foreach (string str in matchResponse)
                {

                    DataRow[] rows = dtAnswersAgainstQuestion.Select(Entities.VSearchAnswersByTestTakerId.CATEGORY_BASED_FORMAT + "='" + str + "'");
                    if (rows == null || rows.Length <= 0)
                    {
                        status = Enumaration.TestTakerQuestionStatus.Wrong;
                        break;
                    }


                }
            }
            else
            {
                status = Enumaration.TestTakerQuestionStatus.Wrong;
            }
            caseClauseForStatus.Append(string.Format(caseTemplate, ((int)status).ToString()));
            caseClauseForResponse.Append(string.Format(caseTemplateForResponse, subResponse[2]));
        }

        private static void CompileMatchImageWithImageAndMatchImageWithTextResult(DataTable dtAnswers, StringBuilder caseClauseForStatus,
             StringBuilder caseClauseForResponse, string[] subResponse, string questionId, string caseTemplate, string caseTemplateForResponse)
        {
            Enumaration.TestTakerQuestionStatus status = Enumaration.TestTakerQuestionStatus.Right;
            
            string[] matchResponse = subResponse[2].Substring(0,subResponse[2].Length-1).Split(':');
            DataRow[] rowsMatchingQuestionId = dtAnswers.Select(Entities.QuestionsPool.ID + " = " + questionId );
            DataTable dtAnswersAgainstQuestion= new DataTable();
            dtAnswersAgainstQuestion = rowsMatchingQuestionId.CopyToDataTable();
            //Check if user's answered items count is equal to total number of answers against the question
            if (matchResponse.Length == rowsMatchingQuestionId.Length)
            {
                foreach (string str in matchResponse)
                {

                    DataRow[] rows = dtAnswersAgainstQuestion.Select(Entities.VSearchAnswersByTestTakerId.IMAGE_MATCH_FORMAT + "='" + str+"'");
                    if (rows == null || rows.Length <= 0)
                    {
                        status = Enumaration.TestTakerQuestionStatus.Wrong;
                        break;
                    }
                }
            }
            else
            {
                status = Enumaration.TestTakerQuestionStatus.Wrong;
            }
            caseClauseForStatus.Append( string.Format( caseTemplate, ( ( int ) status ).ToString() ) );
            caseClauseForResponse.Append(string.Format(caseTemplateForResponse, subResponse[2]));
         }
            
        }
    
}

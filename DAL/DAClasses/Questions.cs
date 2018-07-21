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
    public class Questions
    {


        public DataSet Search(Dictionary<Enumaration.SearchQuestionsCriteria, Object> criteria,int pageToRetrieve,String orderBy)
        {
            DataSet ds = new DataSet();
            DAQuestionsPool oDa = new DAQuestionsPool();
            ds = oDa.SearchQuestions(criteria, pageToRetrieve, orderBy,Enumaration.RecordsPerPage);
            return ds;
        }

        public DataSet GetQuestionsById(string questionId)
        {

            DAQuestionsPool oDa = new DAQuestionsPool();
            return oDa.GetQuesitonsById(questionId);

        }
        
        public static DataSet GetDataSetForManageQuestions( int questionType )
        {
           DataSet ds = new DataSet();
           
           DataTable dtQp = Entities.QuestionsPool.GetDataTable() ;
           dtQp.Rows.Add(dtQp.NewRow());
           DataRow dtQpRow = dtQp.Rows[0];
           dtQpRow[Entities.QuestionsPool.STATUS] = (int)Enumaration.QuestionsStatus.Created;
           ds.Tables.Add(dtQp);
            
           DataTable dtQuestionTextCultureRes = Entities.CultureResources.GetDataTable();
           dtQuestionTextCultureRes.TableName = Enumaration.ManageQuestionKeys.DT_QuestionTextCultureRes;
           dtQuestionTextCultureRes.Rows.Add(dtQuestionTextCultureRes.NewRow());
           ds.Tables.Add(dtQuestionTextCultureRes);
           //if (questionType.Equals((int)Enumaration.QuestionType.Categorybased))
           //{
               DataTable dtQuestionCatOneCultureRes = Entities.CultureResources.GetDataTable();
               dtQuestionCatOneCultureRes.TableName = Enumaration.ManageQuestionKeys.DT_QuestionCatOneCultureRes;
               dtQuestionCatOneCultureRes.Rows.Add(dtQuestionCatOneCultureRes.NewRow());
               ds.Tables.Add(dtQuestionCatOneCultureRes);

               DataTable dtQuestionCatTwoCultureRes = Entities.CultureResources.GetDataTable();
               dtQuestionCatTwoCultureRes.TableName = Enumaration.ManageQuestionKeys.DT_QuestionCatTwoCultureRes;
               dtQuestionCatTwoCultureRes.Rows.Add(dtQuestionCatTwoCultureRes.NewRow());
               ds.Tables.Add(dtQuestionCatTwoCultureRes);
           //}

           ds.Tables.Add(Entities.AnswersPool.GetDataTable() );
           
           DataTable dtAnswerTextCultureRes = Entities.CultureResources.GetDataTable();
           dtAnswerTextCultureRes.TableName = Enumaration.ManageQuestionKeys.DT_AnswerTextCultureRes;
           ds.Tables.Add(dtAnswerTextCultureRes);

           return ds;
        }

        public void Save(DataSet ds,DbTransaction transaction, Enumaration.PageMode pageMode)
        {
            DataSet dataToSave = ds;
            DataRow drQp = ds.Tables[Entities.QuestionsPool.TABLE_NAME].Rows[0];
            DataTable dtQpCatOne = null;
            DataTable dtQpCatTwo = null;
            DAQuestionsPool oDAQp = new DAQuestionsPool();
            DACultureResources oDACr = new DACultureResources();
            //Saving culture resources for questions:Start
                DataTable dtQpCr = ds.Tables[Enumaration.ManageQuestionKeys.DT_QuestionTextCultureRes];
                oDACr.PersistCultureResource(dtQpCr, transaction);

            //Saving culture resources for questions:Finish
                if (Convert.ToInt16(drQp[Entities.QuestionsPool.TYPE_ID]).Equals((int)Enumaration.QuestionType.Categorybased))
                {
                    //Saving culture resources for CATEGORIES:Start
                    dtQpCatOne = ds.Tables[Enumaration.ManageQuestionKeys.DT_QuestionCatOneCultureRes];
                    oDACr.PersistCultureResource(dtQpCatOne, transaction);

                    dtQpCatTwo = ds.Tables[Enumaration.ManageQuestionKeys.DT_QuestionCatTwoCultureRes];
                    oDACr.PersistCultureResource(dtQpCatTwo, transaction);
                }
            //Saving culture resources for CATEGORIES:Finish
            //Saving questions Start

                
                drQp[Entities.QuestionsPool.QUESTION_TEXT] = (Int64)dtQpCr.Rows[0][Entities.CultureResources.ID];
                if (dtQpCatOne != null && dtQpCatTwo != null)
                {
                    drQp[Entities.QuestionsPool.CATEGORY_ONE] = (Int64)dtQpCatOne.Rows[0][Entities.CultureResources.ID];
                    drQp[Entities.QuestionsPool.CATEGORY_TWO] = (Int64)dtQpCatTwo.Rows[0][Entities.CultureResources.ID];
                }
            
                oDAQp.SaveQuestionsPool(transaction, drQp, pageMode);

            //Saving questions Finish

            DAAnswersPool ODaAp = new DAAnswersPool();
            DataRow[] answersToPersist = ds.Tables[Entities.AnswersPool.TABLE_NAME].Select(
                                                                                            Entities.AnswersPool.IS_NEW + "   =1 OR " +
                                                                                            Entities.AnswersPool.IS_CHANGED + "   =1 OR " +
                                                                                            Entities.AnswersPool.IS_DELETED + "    =1   "

                                                                                           ) ;
            foreach (DataRow drAp in answersToPersist)
            {
                DataRow[] drApCrs = ds.Tables[Enumaration.ManageQuestionKeys.DT_AnswerTextCultureRes].
                                                                    Select(Entities.CultureResources.ID + "=" + drAp[Entities.AnswersPool.ANSWER_TEXT]);

                DataRow drApCr = drApCrs[0];
                if (drAp[Entities.AnswersPool.IS_NEW] != DBNull.Value && drAp[Entities.AnswersPool.IS_NEW].ToString().Equals("1"))
                {
                    drApCr[Entities.CultureResources.ID] = DBNull.Value;
                    drAp[Entities.AnswersPool.ID] = DBNull.Value;

                }

                //Saving culture resources for answer:Start

                    oDACr.PersistCultureResource(drApCr, transaction);

                //Saving culture resources for answer:Finish

                //Saving answers Start

                    drAp[Entities.AnswersPool.QUESTION_ID] = (Int64)drQp[Entities.QuestionsPool.ID];
                    drAp[Entities.AnswersPool.ANSWER_TEXT] = (Int64)drApCr[Entities.CultureResources.ID];

                    if ( drAp[Entities.AnswersPool.IS_NEW].Equals("1") && drAp[Entities.AnswersPool.TEMP_ID_FOR_IMAGE] != DBNull.Value )
                    {
                        String tempIdWithImage = drAp[Entities.AnswersPool.TEMP_ID_FOR_IMAGE].ToString();
                        if (drQp.Table.Columns.Contains(Entities.QuestionsPool.TEMP_ID))
                        {
                            drAp[Entities.AnswersPool.TEMP_ID_FOR_IMAGE] = drQp[Entities.QuestionsPool.TEMP_ID].ToString() + "/" + 
                                                                           drAp[Entities.AnswersPool.TEMP_ID_FOR_IMAGE].ToString();
                        }
                        else
                        {
                            drAp[Entities.AnswersPool.TEMP_ID_FOR_IMAGE] = drQp[Entities.QuestionsPool.ID].ToString() + "/" + 
                                                                           drAp[Entities.AnswersPool.TEMP_ID_FOR_IMAGE].ToString();
                        }
                        ODaAp.SaveAnswers(transaction, drAp);
                        drAp[Entities.AnswersPool.TEMP_ID_FOR_IMAGE] = tempIdWithImage;
                    }
                    else 
                    {
                        ODaAp.SaveAnswers(transaction, drAp);

                    }
                //Saving answers Finish
            


                }
            //Generate Questions XML It should be the last item int the function
            oDAQp.PersistXML(transaction, drQp[Entities.QuestionsPool.ID].ToString());    
         }
          
        }
    }


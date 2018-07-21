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
    public class Slide
    {
        private Dictionary<int, int> dicCategoryTempActualId = new Dictionary<int, int>();
       
        public void Save(DataSet ds, DbTransaction transaction)
        {
            DataRow drSlide = ds.Tables[Entities.TrainingSlide.TABLE_NAME].Rows[0];
            DASlide oDASlide = new DASlide();
            DACultureResources oDACr = new DACultureResources();
            
            //Saving culture resources for slide name:Start
             DataTable dtSlideCr = ds.Tables[Entities.CultureResources.TABLE_NAME];

             PersistSlideCultureText(transaction, drSlide, oDACr, dtSlideCr);
            //Saving culture resources for slide name:Finish
            
            //Saving culture resources for slide main details:Start
            SaveSlideFiles(ds, transaction, drSlide, oDACr);
            //Saving culture resources for slide main details:Finish

            //Saving slide Start
            oDASlide.SaveSlides(transaction, drSlide);
            Int64 slideId = Convert.ToInt64(drSlide[Entities.TrainingSlide.SLIDE_ID]);
            //Saving slide Finish


            switch ( int.Parse(drSlide[Entities.TrainingSlide.SLIDE_TYPE].ToString()) )
            {
                case (int)Enumaration.SlideType.Questionnaire:
                    {
                        SaveSurveyDetails(ds, transaction, oDACr, slideId);
                        break;
                    }
                case (int)Enumaration.SlideType.Navigation:
                    {
                        SaveNavigationDetails(ds, transaction, oDACr, slideId);
                        break;
                    }

            }
           
            
       }

        private static void PersistSlideCultureText(DbTransaction transaction, DataRow drSlide, DACultureResources oDACr, DataTable dtSlideCr)
        {

            foreach (DataRow row in dtSlideCr.Rows)
            {
                string id = row[Entities.CultureResources.ID].ToString();
                if (row[Entities.CultureResources.IS_NEW] != DBNull.Value &&
                     row[Entities.CultureResources.IS_NEW].ToString().Equals("1")
                   )
                {
                    row[Entities.CultureResources.ID] = DBNull.Value;

                }
                oDACr.PersistCultureResource(row, transaction);
                if (drSlide[Entities.TrainingSlide.SLIDE_NAME].ToString().Equals(id))
                {
                    drSlide[Entities.TrainingSlide.SLIDE_NAME] = Convert.ToInt64(row[Entities.CultureResources.ID]);
                }
                else if (drSlide[Entities.TrainingSlide.DESCRIPTION].ToString().Equals(id))
                {
                    drSlide[Entities.TrainingSlide.DESCRIPTION] = Convert.ToInt64(row[Entities.CultureResources.ID]);
                }
            }
        }

        public void PersistXML( DataRow drSlide)
        {
            DASlide oDASlide = new DASlide();

            string xmlId = "-1";
            if (drSlide[Entities.TrainingSlide.XML_ID] != DBNull.Value)
            {
                xmlId = drSlide[Entities.TrainingSlide.XML_ID].ToString();
            }
            Entities.SP_USP_SlideCultureXML sp = new Entities.SP_USP_SlideCultureXML( drSlide[Entities.TrainingSlide.SLIDE_ID].ToString(), 
                                                                                      xmlId, 
                                                                                      drSlide[Entities.TrainingSlide.SLIDE_TYPE].ToString()
                                                                                    );
            DataSet dsXML = oDASlide.ExecuteStoredProcedure(Entities.SP_USP_SlideCultureXML.SP_NAME, sp.ParamsList);
            if (xmlId.Equals("-1"))
            {
                drSlide[Entities.TrainingSlide.XML_ID] = Convert.ToInt64(dsXML.Tables[0].Rows[0][Entities.CultureXML.XML_ID].ToString());
                oDASlide.SaveSlides(null,drSlide);

            }
        }

        private void SaveNavigationDetails(DataSet ds, DbTransaction transaction, DACultureResources oDACr, Int64 slideId)
        {
            
            DataTable dtChoice = ds.Tables[Entities.SlideNavigation.TABLE_NAME];
            DataTable dtCR = ds.Tables[Enumaration.ManageSlideKeys.DT_SlideNavigationCultureRes];
            DataTable dtLinks = ds.Tables[Entities.SlideNavigationLinks.TABLE_NAME];
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            foreach (DataRow dr in dtCR.Rows)
            {
                string key = string.Empty;
                key = dr[Entities.CultureResources.ID].ToString();
                if ( dr[Entities.CultureResources.IS_NEW].ToString().Equals("1") )
                {
                    //key = dr[Entities.CultureResources.ID].ToString();
                    dr[Entities.CultureResources.ID] = DBNull.Value;
                }
                oDACr.PersistCultureResource(dr, transaction);
                //if (dr[Entities.CultureResources.IS_NEW].ToString().Equals("1"))
                //{
                    dictionary.Add(key, dr[Entities.CultureResources.ID].ToString());
                //}
            }
            
            DASlideNavigation oDA = new DASlideNavigation();
            DASlideNavLinks oDALinks = new DASlideNavLinks();
            foreach (DataRow dr in dtChoice.Rows)
            {
                string navigationChoiceId = string.Empty;
                bool isNewOrChanged = ( dr[Entities.SlideNavigation.IS_NEW].ToString().Equals("1") ||
                                        dr[Entities.SlideNavigation.IS_CHANGED].ToString().Equals("1") 
                                      );
                bool isIncompleteAddition = dr[Entities.SlideNavigation.IS_ADDING].ToString().Equals("1");
                string oldNavigationChoiceId = string.Empty;
                if (  isNewOrChanged && !isIncompleteAddition)
                {
                    if ( dr[Entities.SlideNavigation.IS_NEW].ToString().Equals("1") )
                    {
                        oldNavigationChoiceId = dr[Entities.SlideNavigation.NAVIGATION_CHOICE_ID].ToString();
                        dr[Entities.SlideNavigation.NAVIGATION_CHOICE_ID] = DBNull.Value;
                        dr[Entities.SlideNavigation.SLIDE_ID] = slideId;
                    }
                    else
                    {
                         oldNavigationChoiceId = dr[Entities.SlideNavigation.NAVIGATION_CHOICE_ID].ToString();
                    }
  
                    if (dictionary.ContainsKey(dr[Entities.SlideNavigation.TITLE].ToString()))
                    {
                        dr[Entities.SlideNavigation.TITLE] = Convert.ToInt64(dictionary[dr[Entities.SlideNavigation.TITLE].ToString()]);
                    }
                    if (dictionary.ContainsKey(dr[Entities.SlideNavigation.AUDIO].ToString()))
                    {
                        dr[Entities.SlideNavigation.AUDIO] = Convert.ToInt64(dictionary[dr[Entities.SlideNavigation.AUDIO].ToString()]);
                    }
                    else
                    {
                        dr[Entities.SlideNavigation.AUDIO] = DBNull.Value;
                    }
                    if (dictionary.ContainsKey(dr[Entities.SlideNavigation.DESCRIPTION].ToString()))
                    {
                        dr[Entities.SlideNavigation.DESCRIPTION] = Convert.ToInt64(dictionary[dr[Entities.SlideNavigation.DESCRIPTION].ToString()]);
                    }
                    else
                    {
                        dr[Entities.SlideNavigation.DESCRIPTION] = DBNull.Value;
                    }
                    if (dictionary.ContainsKey(dr[Entities.SlideNavigation.IMAGE].ToString()))
                    {
                        dr[Entities.SlideNavigation.IMAGE] = Convert.ToInt64(dictionary[dr[Entities.SlideNavigation.IMAGE].ToString()]);
                    }
                    else
                    {
                        dr[Entities.SlideNavigation.IMAGE] = DBNull.Value;
                    }
                    if (dictionary.ContainsKey(dr[Entities.SlideNavigation.VIDEO].ToString()))
                    {
                        dr[Entities.SlideNavigation.VIDEO] = Convert.ToInt64(dictionary[dr[Entities.SlideNavigation.VIDEO].ToString()]);
                    }
                    else
                    {
                        dr[Entities.SlideNavigation.VIDEO] = DBNull.Value;
                    }
                    oDA.Save(transaction, dr);
                    navigationChoiceId = dr[Entities.SlideNavigation.NAVIGATION_CHOICE_ID].ToString();
                    DataRow[] links = dtLinks.Select(Entities.SlideNavigationLinks.NAVIGATION_CHOICE_ID + "=" + oldNavigationChoiceId);
                    foreach (DataRow link in links)
                    {
                        isNewOrChanged = (link[Entities.SlideNavigationLinks.IS_NEW].ToString().Equals("1") ||
                                        link[Entities.SlideNavigationLinks.IS_CHANGED].ToString().Equals("1")
                                      );
                        isIncompleteAddition = link[Entities.SlideNavigationLinks.IS_ADDING].ToString().Equals("1");
                        if (isIncompleteAddition || !isNewOrChanged )
                        {
                            continue;
                        }
                        link[Entities.SlideNavigationLinks.NAVIGATION_CHOICE_ID] = Convert.ToInt64(navigationChoiceId);
                        if (dictionary.ContainsKey(link[Entities.SlideNavigationLinks.FILE_LINK].ToString()))
                        {
                            link[Entities.SlideNavigationLinks.FILE_LINK] = Convert.ToInt64(dictionary[link[Entities.SlideNavigationLinks.FILE_LINK].ToString()]);
                        }
                        else
                        {
                            link[Entities.SlideNavigationLinks.FILE_LINK] = DBNull.Value;
                        }
                        if (dictionary.ContainsKey(link[Entities.SlideNavigationLinks.DESCRIPTION].ToString()))
                        {
                            link[Entities.SlideNavigationLinks.DESCRIPTION] = Convert.ToInt64(dictionary[link[Entities.SlideNavigationLinks.DESCRIPTION].ToString()]);
                        }
                        else
                        {
                            link[Entities.SlideNavigationLinks.DESCRIPTION] = DBNull.Value;
                        }
                        oDALinks.Save(transaction, link);
                    }
                }
                
                
            }

        }
        
        private  void SaveSurveyDetails(DataSet ds, DbTransaction transaction, DACultureResources oDACr, Int64 slideId)
        {

            //Saving Categories Start
            SaveSurveyCategories(ds, transaction, oDACr, slideId);
            //Saving Categories Finish


            //Saving Choice Start
            SaveSurveyChoices(ds, transaction, oDACr, slideId);
            //Saving Choice Finish

            //Saving Questions Start
            SaveSurveyQuestions(ds, transaction, oDACr, slideId);
            //Saving Questions Finish
        }
        
        private  void SaveSurveyCategories(DataSet ds, DbTransaction transaction, DACultureResources oDACr,Int64 slideId)
        {
            DASlideSurveyCategory oDACat = new DASlideSurveyCategory();
            DataTable dtCategory = ds.Tables[Entities.SlideSurveyCategory.TABLE_NAME];

            foreach (DataRow dr in dtCategory.Rows)
            {
                if (!dr[Entities.SlideSurveyCategory.IS_CHANGED].ToString().Equals("1") && 
                    !dr[Entities.SlideSurveyCategory.IS_NEW].ToString().Equals("1") &&
                    !dr[Entities.SlideSurveyCategory.IS_DELETED].ToString().Equals("1") 
                   )
                {
                    continue;
                }
                DataTable dtCategoryCulture = Entities.CultureResources.GetDataTable();
                DataRow row = dtCategoryCulture.NewRow();
                foreach (DataColumn col in dtCategoryCulture.Columns)
                {
                    if (dtCategory.Columns.Contains(col.ColumnName))
                    {
                        row[col.ColumnName] = dr[col.ColumnName];
                    }
                }
                row[Entities.CultureResources.ID] = dr[Entities.SlideSurveyCategory.CATEGORY_TEXT];
                int tempCategoryId = -1;
                oDACr.PersistCultureResource(row, transaction);
                if (dr[Entities.SlideSurveyCategory.IS_NEW].ToString().Equals("1"))
                {
                    dr[Entities.SlideSurveyCategory.CATEGORY_TEXT] = row[Entities.CultureResources.ID];
                    dr[Entities.SlideSurveyCategory.SLIDE_ID] = slideId;
                    tempCategoryId = Convert.ToInt32(  dr[Entities.SlideSurveyCategory.CATEGORY_ID] );
                    
                    dr[Entities.SlideSurveyCategory.CATEGORY_ID] = DBNull.Value;
                }
                oDACat.Save(transaction, dr);
                //adding for the first time we assign a temp id to category. If this category has been associated with the survey question then we 
                //have to remove the temp id from survey question and assign the db id to it.For this purpose we are storing temp id in dictionary along
                //with the db id.Later on adding survey questions we will retrieve the db id from this dictionary and change the temp id of question category
                if ( tempCategoryId > 0)
                {
                    dicCategoryTempActualId.Add(  tempCategoryId, 
                                                  Convert.ToInt32( dr[Entities.SlideSurveyCategory.CATEGORY_ID] )
                                                );
                }
            }
        }

        private static void SaveSurveyChoices(DataSet ds, DbTransaction transaction, DACultureResources oDACr, Int64 slideId)
        {
            DASurveyChoices oDACat = new DASurveyChoices();
            DataTable dtChoice = ds.Tables[Entities.SlideSurveyChoices.TABLE_NAME];

            foreach (DataRow dr in dtChoice.Rows)
            {
                if (!dr[Entities.SlideSurveyChoices.IS_CHANGED].ToString().Equals("1") && 
                    !dr[Entities.SlideSurveyChoices.IS_NEW].ToString().Equals("1") &&
                    !dr[Entities.SlideSurveyChoices.IS_DELETED].ToString().Equals("1")  )
                {
                    continue;
                }
                DataTable dtCulture = Entities.CultureResources.GetDataTable();
                DataRow row = dtCulture.NewRow();
                foreach (DataColumn col in dtCulture.Columns)
                {
                    if (dtChoice.Columns.Contains(col.ColumnName))
                    {
                        row[col.ColumnName] = dr[col.ColumnName];
                    }
                }
                row[Entities.CultureResources.ID] = dr[Entities.SlideSurveyChoices.CHOICE_TEXT];
                oDACr.PersistCultureResource(row, transaction);
                if (dr[Entities.SlideSurveyChoices.IS_NEW].ToString().Equals("1"))
                {
                    dr[Entities.SlideSurveyChoices.CHOICE_TEXT] = row[Entities.CultureResources.ID];
                    dr[Entities.SlideSurveyChoices.SLIDE_ID] = slideId;
                    dr[Entities.SlideSurveyChoices.CHOICE_ID] = DBNull.Value;
                }
                oDACat.Save(transaction, dr);
            }
        }

        private  void SaveSurveyQuestions(DataSet ds, DbTransaction transaction, DACultureResources oDACr, Int64 slideId)
        {
            DASurveyQuestion oDA = new DASurveyQuestion();
            DataTable dtSurveyQuestion = ds.Tables[Entities.SlideSurveyQuestions.TABLE_NAME];

            foreach (DataRow dr in dtSurveyQuestion.Rows)
            {
                //Only persist those rows that are new or changed
                if (!dr[Entities.SlideSurveyQuestions.IS_CHANGED].ToString().Equals("1") &&
                    !dr[Entities.SlideSurveyQuestions.IS_NEW].ToString().Equals("1") &&
                    !dr[Entities.SlideSurveyQuestions.IS_DELETED].ToString().Equals("1"))
                {
                    continue;
                }
                DataTable dtQuestionCulture = Entities.CultureResources.GetDataTable();
                DataRow row = dtQuestionCulture.NewRow();
                foreach (DataColumn col in dtQuestionCulture.Columns)
                {
                    if (dtSurveyQuestion.Columns.Contains(col.ColumnName))
                    {
                        row[col.ColumnName] = dr[col.ColumnName];
                    }
                }
                row[Entities.CultureResources.ID] = dr[Entities.SlideSurveyQuestions.SURVEY_QUESTION_TEXT];
                oDACr.PersistCultureResource(row, transaction);
                int id = Convert.ToInt32(dr[Entities.SlideSurveyQuestions.CATEGORY_ID]);
                if (dr[Entities.SlideSurveyQuestions.IS_NEW].ToString().Equals("1"))
                {
                    dr[Entities.SlideSurveyQuestions.SURVEY_QUESTION_TEXT] = row[Entities.CultureResources.ID];
                    dr[Entities.SlideSurveyQuestions.SLIDE_ID] = slideId;
                    dr[Entities.SlideSurveyQuestions.SURVEY_QUESTION_ID] = DBNull.Value;
                    
                    
                }
                if (dicCategoryTempActualId.ContainsKey(id))
                {
                    dr[Entities.SlideSurveyQuestions.CATEGORY_ID] = dicCategoryTempActualId[id];

                }
                oDA.Save(transaction, dr);
            }
        }

        private void SaveSlideFiles(DataSet ds, DbTransaction transaction, DataRow drSlide, DACultureResources oDACr)
        {
            DataTable dtSlideFileUpload = ds.Tables[Enumaration.ManageSlideKeys.DT_SlideFileUploadCultureRes];
            foreach (DataRow dr in dtSlideFileUpload.Rows)
            {

                oDACr.PersistCultureResource(dr, transaction);
                switch (dr[Entities.CultureResources.TYPE].ToString())
                {

                    case "1":
                        drSlide[Entities.TrainingSlide.ANIMATION_ID] = dr[Entities.CultureResources.ID];
                        break;
                    case "2":
                        drSlide[Entities.TrainingSlide.AUDIO_ID] = dr[Entities.CultureResources.ID];
                        break;
                    case "3":
                        drSlide[Entities.TrainingSlide.IMAGE_ID] = dr[Entities.CultureResources.ID];
                        break;
                }
            }
        }

        public DataSet Search(Dictionary<Enumaration.SearchSlideCriteria, Object> criteria, int pageToRetrieve, String orderBy)
        {
            DataSet ds = new DataSet();
            DASlide oDa = new DASlide();
            ds = oDa.Search(criteria, pageToRetrieve, orderBy, Enumaration.RecordsPerPage);

            return ds;
        }

        public static DataSet GetDataSetForSlide(int slideType)
        {
            DataSet ds = new DataSet();

            DataTable dtSlide = Entities.TrainingSlide.GetDataTable();
            DataRow slideRow = dtSlide.NewRow();
            dtSlide.Rows.Add( slideRow );
            ds.Tables.Add(dtSlide);

            DataTable dtSlideTextsCultureRes = Entities.CultureResources.GetDataTable();

            DataRow slideName = dtSlideTextsCultureRes.NewRow();
            slideName[Entities.CultureResources.ID] = slideName.GetHashCode();
            slideName[Entities.CultureResources.IS_NEW] = "1";
            dtSlideTextsCultureRes.Rows.Add(slideName);
            slideRow[Entities.TrainingSlide.SLIDE_NAME] = slideName[Entities.CultureResources.ID];

            DataRow slideDesc = dtSlideTextsCultureRes.NewRow();
            slideDesc[Entities.CultureResources.ID] = slideDesc.GetHashCode();
            slideDesc[Entities.CultureResources.IS_NEW] = "1";
            dtSlideTextsCultureRes.Rows.Add(slideDesc);
            slideRow[Entities.TrainingSlide.DESCRIPTION] = slideDesc[Entities.CultureResources.ID];
            
            ds.Tables.Add(dtSlideTextsCultureRes);
                        
            
                        
            DataTable dtFileUploadCultureRes = Entities.CultureResources.GetDataTable();
            dtFileUploadCultureRes.TableName = Enumaration.ManageSlideKeys.DT_SlideFileUploadCultureRes;
             
            for (int i = 1; i < 4; i++)
            {
                
                DataRow row = dtFileUploadCultureRes.NewRow();
                row["TYPE"] = i.ToString();
                dtFileUploadCultureRes.Rows.Add(row);

            }
            ds.Tables.Add( dtFileUploadCultureRes );
            if( slideType == (int)Enumaration.SlideType.Questionnaire )
            {
                GetDataTableForSlideSurvey(ds);
            }
            else if (slideType == (int)Enumaration.SlideType.Navigation)
            {
                GetDataTableForSlideNavigation(ds);
            }

            return ds;
        }

        public static void GetDataTableForSlideSurvey(DataSet ds)
        {
            ds.Tables.Add(Entities.SlideSurveyCategory.GetDataTable());
            ds.Tables.Add(Entities.SlideSurveyChoices.GetDataTable());
            ds.Tables.Add(Entities.SlideSurveyQuestions.GetDataTable());
        }

        public static void GetDataTableForSlideNavigation(DataSet ds)
        {
            ds.Tables.Add(Entities.SlideNavigation.GetDataTable());
            DataTable dtCr = Entities.CultureResources.GetDataTable();
            dtCr.TableName = Enumaration.ManageSlideKeys.DT_SlideNavigationCultureRes;
            ds.Tables.Add(dtCr);
            ds.Tables.Add(Entities.SlideNavigationLinks.GetDataTable());
            
        }

        public DataSet GetSlideById(string slideId)
        {
            DASlide oDASlide = new DASlide();
            return oDASlide.GetSlideById(slideId);
        }
        public Boolean IsSlideNameDuplicated( DataRow slideRow,DataRow cultureRes )
        {
            DASlide oDASlide = new DASlide();
            return oDASlide.IsSlideNameDuplicated(slideRow,cultureRes);
        }          
    }
    
}

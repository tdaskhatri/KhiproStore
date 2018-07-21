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
    public class Course
    {
        public void Save(DataSet ds, DbTransaction transaction)
        {
            DataRow drCourse = ds.Tables[Entities.Course.TABLE_NAME].Rows[0];
            DACourse oDACourse = new DACourse();
            DACourseMaterial oDACourseMaterial = new DACourseMaterial();
            DACultureResources oDACr = new DACultureResources();
            
            //Saving culture resources for Course name:Start

             DataTable dtCourseCr = ds.Tables[Entities.CultureResources.TABLE_NAME];
             oDACr.PersistCultureResource(dtCourseCr, transaction);
             drCourse[Entities.Course.COURSE_NAME] = (Int64)dtCourseCr.Rows[0][Entities.CultureResources.ID];
            
            //Saving culture resources for Course name:Finish


             //Saving culture resources for Course desc:Start

             DataTable dtCourseDescCr = ds.Tables[Enumaration.ManageCourseKeys.DT_CourseDescriptionCultureRes];
             oDACr.PersistCultureResource(dtCourseDescCr, transaction);
             drCourse[Entities.Course.DESCRIPTION] = (Int64)dtCourseDescCr.Rows[0][Entities.CultureResources.ID];

             //Saving culture resources for Course desc:Finish

             //Saving culture resources for Course Icon:Start

             DataTable dtCourseIconCr = ds.Tables[Enumaration.ManageCourseKeys.DT_CourseFileUploadCultureRes];
             oDACr.PersistCultureResource(dtCourseIconCr, transaction);
             drCourse[Entities.Course.ICON] = (Int64)dtCourseIconCr.Rows[0][Entities.CultureResources.ID];

             //Saving culture resources for Course Icon:Finish
             
             
            //Saving Course Start

             oDACourse.SaveCourse(transaction, drCourse);
             string courseId = drCourse[Entities.Course.COURSE_ID].ToString();
            //Saving Course Finish
            //Saving Course Material Start

             DataTable dtCourseMaterial = ds.Tables[Entities.CourseMaterial.TABLE_NAME];
             oDACourseMaterial.DeleteCourseMaterialForCourseId(transaction, courseId);
             foreach (DataRow row in dtCourseMaterial.Rows)
             {
                 row[Entities.CourseMaterial.COURSE_MATERIAL_ID] = DBNull.Value;
                 row[Entities.CourseMaterial.COURSE_ID] = int.Parse(courseId);
                 oDACourseMaterial.SaveCourseMaterial(transaction, row);
             }
            
            //Saving Course Material  Finish
       }

        public void PersistXML(DataRow drCourse, DACourse oDACourse)
       {
           

            string xmlId = "-1";
            if (drCourse[Entities.Course.XML_ID] != DBNull.Value)
            {
                xmlId = drCourse[Entities.Course.XML_ID].ToString();
            }
            Entities.SP_USP_CourseCultureXML sp = new Entities.SP_USP_CourseCultureXML( drCourse[Entities.Course.COURSE_ID].ToString(),
                                                                                        xmlId 
                                                                                      );
            DataSet dsXML = oDACourse.ExecuteStoredProcedure(Entities.SP_USP_CourseCultureXML.SP_NAME, sp.ParamsList);
            if (xmlId.Equals("-1"))
            {
                drCourse[Entities.Course.XML_ID] = Convert.ToInt64(dsXML.Tables[0].Rows[0][Entities.CultureXML.XML_ID].ToString());
                oDACourse.SaveCourse(null, drCourse);

            }
       }

        public DataSet Search(Dictionary<Enumaration.SearchCourseCriteria, Object> criteria, int pageToRetrieve, String orderBy)
        {
            DataSet ds = new DataSet();
            DACourse oDa = new DACourse();
            ds = oDa.Search(criteria, pageToRetrieve, orderBy, Enumaration.RecordsPerPage);

            return ds;
        }
     
        public static DataSet GetDataSetForCourse()
        {
            DataSet ds = new DataSet();

            DataTable dtCourse = Entities.Course.GetDataTable();
            dtCourse.Rows.Add(dtCourse.NewRow());
            ds.Tables.Add(dtCourse);
            
            DataTable dtCourseTextsCultureRes = Entities.CultureResources.GetDataTable();
            dtCourseTextsCultureRes.Rows.Add(dtCourseTextsCultureRes.NewRow());
            ds.Tables.Add(dtCourseTextsCultureRes);

            DataTable dtFileUploadCultureRes = Entities.CultureResources.GetDataTable();
            dtFileUploadCultureRes.TableName = Enumaration.ManageCourseKeys.DT_CourseFileUploadCultureRes;
            for (int i = 1; i < 2; i++)
            {

                DataRow row = dtFileUploadCultureRes.NewRow();
                row["TYPE"] = i.ToString();
                dtFileUploadCultureRes.Rows.Add(row);

            }
            ds.Tables.Add(dtFileUploadCultureRes);

            DataTable dtCourseDescCultureRes = Entities.CultureResources.GetDataTable();
            dtCourseDescCultureRes.TableName = Enumaration.ManageCourseKeys.DT_CourseDescriptionCultureRes;
            dtCourseDescCultureRes.Rows.Add(dtCourseDescCultureRes.NewRow());
            ds.Tables.Add(dtCourseDescCultureRes);

            ds.Tables.Add(Entities.CourseMaterial.GetDataTable());
            
            return ds;
        }
        
        public DataSet GetCourseById(string CourseId)
        {
            DACourse oDACourse = new DACourse();
            return oDACourse.GetCourseById(CourseId);
        }

        public DataTable GetCourseXML(string courseId)
        {
            DACourse oDACourse = new DACourse();
            return oDACourse.GetCourseXML(courseId);
        }

    }
    
}

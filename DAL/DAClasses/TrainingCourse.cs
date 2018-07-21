using eLearning.Common.Utils;
using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace eLearning.DAL.DAClasses
{
    // Added by AVANZA\muhammad.uzair on 12/10/2017 09:57:26
    [Serializable]
    public class TrainingCourse
    {
        private DATrainingCourse daTrainingCourse;
        private const string MODULE_NAME = "Training Course";
        Logger logger;

        public TrainingCourse()
        {
            daTrainingCourse = new DATrainingCourse();
            logger = Logger.getInstance();
        }

        #region BusinessLogics
        
        // Added by AVANZA\muhammad.uzair on 16/10/2017 15:21:58
        public DataTable GetActiveCompanies(string companyTypeId)
        {
            try
            {
                return daTrainingCourse.GetActiveCompanies(companyTypeId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // Added by AVANZA\muhammad.uzair on 12/10/2017 11:04:05
        public DataTable GetActiveChapters()
        {
            return daTrainingCourse.GetActiveChapters();
        }

        // Added by AVANZA\muhammad.uzair on 12/10/2017 11:04:01
        public DataTable GetCourses(string whereClause)
        {
            return daTrainingCourse.GetCourses(whereClause);
        }

        public void SaveCourse(DataTable dt)
        {
            try
            {
                daTrainingCourse.SaveCourse(dt);
            }
            catch(Exception ex)
            {
                logger.Error(MODULE_NAME, "SaveCourse", ex);
                throw ex;
            }
        }

        //Added by Fahim Nasir 04/12/2017 11:09:09 -- Try Catch
        // Added by AVANZA\muhammad.uzair on 17/10/2017 18:01:28
        public void UpdateCourse(string courseId, DataTable dt)
        {
            try
            {
                daTrainingCourse.UpdateCourse(courseId, dt);
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "UpdateCourse", ex);
                throw ex;
            }            
        }

        // Added by VIJAY\Administrator on 13/10/2017 14:55:49
        public DataTable GetTrainings()
        {
            return daTrainingCourse.GetTrainings();
        }

        // Added by AVANZA\muhammad.uzair on 17/10/2017 10:50:09
        public DataTable GetCourses()
        {
            return daTrainingCourse.GetCourses();
        }

        public DataTable GetSearchTraining(bool isEnglishLocale, string where)
        {
            return daTrainingCourse.GetSearchTraining(isEnglishLocale, where);
        }

        // Added by AVANZA\muhammad.uzair on 17/10/2017 10:50:15
        public int GetParentType(int count)
        {
            return daTrainingCourse.GetParentCount(count);
        }

        // Added by AVANZA\muhammad.uzair on 17/10/2017 10:50:18
        public DataTable SubCategory(int id)
        {
            return daTrainingCourse.GetSubCategory(id);
        }

        // Added by AVANZA\muhammad.uzair on 17/10/2017 10:50:22
        public DataTable GetTrainingTypes()
        {
            try
            {
                return daTrainingCourse.GetTrainingTypes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetTrainingSubType(string parentTrainingId)
        {
            try
            {
                return daTrainingCourse.GetTrainingSubType(parentTrainingId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Added by AVANZA\muhammad.uzair on 16/10/2017 12:06:03
        public DataTable GetChapterWiseCourses(string chapterId)
        {
            try
            {
                return daTrainingCourse.GetChapterWiseCourses(chapterId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Added by AVANZA\muhammad.uzair on 16/10/2017 13:39:24
        public DataTable GetCourseDetails()
        {
            try
            {
                return daTrainingCourse.GetCourseDetails();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // Added by AVANZA\muhammad.uzair on 16/10/2017 18:25:01
        public void SaveTraining(DataTable training, DataTable training_course)
        {
            try
            {
                daTrainingCourse.SaveTraining(training, training_course);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Added by AVANZA\muhammad.uzair on 17/10/2017 12:27:11
        public void SaveTraining(DataTable training, DataTable training_courses, DataTable subServices)
        {
            try
            {
                daTrainingCourse.SaveTraining(training, training_courses, subServices);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Added by AVANZA\muhammad.uzair on 17/10/2017 17:37:00
        public void UpdateTraining(string trainingId, DataTable training, DataTable training_courses)
        {
            daTrainingCourse.UpdateTraining(trainingId, training, training_courses);
        }

        // Added by AVANZA\muhammad.uzair on 17/10/2017 17:38:12
        public void UpdateTraining(string trainingId, DataTable training, DataTable training_courses, DataTable subServices)
        {
            daTrainingCourse.UpdateTraining(trainingId, training, training_courses, subServices);
        }

        // Added by AVANZA\muhammad.uzair on 16/10/2017 19:18:30
        public DataTable GetCourseDetailsById(string courseId)
        {
            try
            {
                return daTrainingCourse.GetCourseDetailsById(courseId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Added by AVANZA\muhammad.uzair on 17/10/2017 11:51:36
        public DataTable GetTrainingLanguages()
        {
            return daTrainingCourse.GetTrainingLanguages();
        }
        
        // Added by AVANZA\muhammad.uzair on 17/10/2017 12:06:11
        public DataSet GetVehicles()
        {
            return daTrainingCourse.GetVehicles();
        }

        // Added by AVANZA\muhammad.uzair on 17/10/2017 16:03:32
        public DataSet GetTrainingById(string trainingId)
        {
            return daTrainingCourse.GetTrainingById(trainingId);
        }

        // Added by AVANZA\muhammad.uzair on 18/10/2017 15:29:40
        public DataTable GetDepotsByCompanyId(string companyId)
        {
            return daTrainingCourse.GetDepotsByCompany(companyId);
        }

        // Added by AVANZA\muhammad.uzair on 18/10/2017 16:38:12
        public DataTable GetExamsByTraining(string isETDI, string isETTC)
        {
            return daTrainingCourse.GetExamsByTraining(isETDI,isETTC);
        }

        #endregion
    }
}

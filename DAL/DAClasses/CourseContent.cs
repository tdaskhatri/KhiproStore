using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace eLearning.DAL.DAClasses
{
    public class CourseContentService
    {
        private DACourseContent DA = new DACourseContent();
        public int GetNextId(string TableName)
        {
            return this.DA.GetNextToken(TableName);
        }
        public void PublishCourseContent(DataRow row)
        {
            this.DA.PublishCourseContent(row);
        }
    }
}

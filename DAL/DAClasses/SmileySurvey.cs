using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace eLearning.DAL.DAClasses
{
    public class SmileySurvey
    {
        private DASmileySurvey DA = new DASmileySurvey();

        public void RecordResponse(string userId, bool isHappy, bool isSad, bool isNormal, int channelID)
        {
            this.DA.InsertSurvey(userId, isHappy, isSad, isNormal, channelID, "null");
        }
    }
}

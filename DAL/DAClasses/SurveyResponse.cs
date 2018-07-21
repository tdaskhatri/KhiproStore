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
    public class SurveyResponse
    {
        string slideId = string.Empty;
        DASurvey oDASurvey = new DASurvey();
        public void PersistResponse(String request, String personId)
        {
            string[] requestParam = request.Split('_');
            slideId = requestParam[0];
            string[] responses = requestParam[1].Split(':');
            oDASurvey.PersistSurveyResponses(responses, personId, slideId);

        }


    }
    
}

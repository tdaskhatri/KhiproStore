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
using System.Linq;
namespace eLearning.DAL.DAClasses
{
    public class DriverAuthentication
    {
        DASecurity objSecurity = null;
        

        #region Login
        

        public static Dictionary<Enumaration.AuthenticateDriverReturnKeys,Object> AuthenticateDriver(string refNum,Enumaration.DriverType dType )
        {
            DataSet dsReturn = new DataSet();
            Dictionary<Enumaration.AuthenticateDriverReturnKeys, Object> dictionary = new Dictionary<Enumaration.AuthenticateDriverReturnKeys, Object>();
            dictionary.Add(Enumaration.AuthenticateDriverReturnKeys.DataSet, dsReturn);
            Enumaration.DriverApplicationLoginStatus loginFlag = Enumaration.DriverApplicationLoginStatus.UnsuccessfullLogin;
            
            DAPersons objPersons = new DAPersons();
            //Check whether person exist in db whose file/driver id number = ref num
            DataSet dsPerson = objPersons.Authenticate(refNum,dType);

            if (dsPerson != null && dsPerson.Tables[0] != null && dsPerson.Tables[0].Rows.Count > 0)
            {
                loginFlag = Enumaration.DriverApplicationLoginStatus.SuccessfullLoginNoTestPresent;
                DataRow person = dsPerson.Tables[0].Rows[0];
                
                dsReturn.Tables.Add(dsPerson.Tables[0].Copy());
                dsReturn.Tables[0].TableName = Entities.Persons.TABLE_NAME;
                DATest oDaTest = new DATest();
                //Check if today,there are tests scheduled for person 
                DataSet dsScheduledTests = oDaTest.GetScheduledTestsByPersonId( person[Entities.Persons.PERSON_ID].ToString() );
                
                if (dsScheduledTests != null && dsScheduledTests.Tables[0] != null && dsScheduledTests.Tables[0].Rows.Count > 0)
                {
                    DataTable dtScheduledTests = dsScheduledTests.Tables[0];
                    loginFlag = Enumaration.DriverApplicationLoginStatus.SuccessfullTestPresent;
                    
                    //Check if test (startdatetime + grace period) > current date time if yes select the first test available
                    var allowedTest =( from scheduledTests in dsScheduledTests.Tables[0].AsEnumerable()
                                       where scheduledTests.Field<String>( Entities.VSearchScheduledTestsByPersonId.IS_TEST_ALLOWED ).Equals("1")
                                       select scheduledTests
                                      ).FirstOrDefault<DataRow>();
                    DataTable dtTest = dtScheduledTests.Clone();
                    

                    if (allowedTest == null)
                    {
                        loginFlag = Enumaration.DriverApplicationLoginStatus.SuccessfullNoTestTimeOut;
                        var testsTimedOut = (
                                              from scheduledTests in dsScheduledTests.Tables[0].AsEnumerable()
                                              where scheduledTests.Field<String>(Entities.VSearchScheduledTestsByPersonId.IS_TEST_ALLOWED).Equals("0")
                                              select    scheduledTests
                                            ).ToArray<DataRow>();

                        dtTest = testsTimedOut.CopyToDataTable();
                    }
                    else
                    {

                        dtTest.ImportRow(allowedTest);
                    }
                    dtTest.TableName = Entities.VSearchScheduledTestsByPersonId.VIEW_NAME;
                    dsReturn.Tables.Add(dtTest);
                }
            }
            dictionary.Add(Enumaration.AuthenticateDriverReturnKeys.LoginFlag, loginFlag);
            return dictionary;
        }
        #endregion
       
    }
}

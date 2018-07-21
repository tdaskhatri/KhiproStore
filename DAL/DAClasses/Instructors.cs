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
    public class Instructors
    {
        private DAInstructor DA = new DAInstructor();

        public int fetchUserId(string id)
        {
            return DA.fetchUserId(id);
        }

        //Added by Fahim Nasir onsite.
        public DataSet Search(Dictionary<Enumaration.SearchInstructorCriteria, Object> criteria)
        {
            return DA.Search(criteria);
        }
        public DataSet Search(Dictionary<Enumaration.SearchInstructorCriteria, Object> criteria, int pageToRetrieve, String orderBy)
        {
            return DA.Search(criteria, pageToRetrieve, orderBy, Enumaration.RecordsPerPage);
        }
        #region Fetch
        public DataSet FetchShifts()
        {
            return this.DA.FetchShifts();
        }
        public DataSet FetchEmirates()
        {
            return this.DA.FetchEmirates();
        }
        public DataSet FetchNationalities()
        {
            return this.DA.FetchNationalities();
        }
        public DataSet FetchLanguages()
        {
            return this.DA.FetchLanguages();
        }
        public DataSet FetchActiveLanguages()
        {
            return this.DA.FetchActiveLanguages();
        }
        public DataSet FetchVehicleTypes()
        {
            return this.DA.FetchVehicleTypes();
        }
        
        public DataSet FetchCenters()
        {
            return this.DA.FetchCenters();
        }
        public DataSet FetchCentersByEmirates(string id)
        {
            return this.DA.FetchCentersByEmirates(id);
        }
        public DataSet FetchBranches()
        {
            return this.DA.FetchBranches();
        }
        public DataSet FetchBranchByCenter(string id)
        {
            return this.DA.FetchBranchesByCenter( id);
        }
        public DataSet FetchServiceRates()
        {
            return this.DA.FetchServiceRates();
        }
        public DataSet FetchLicensedVehicles()
        {
            return this.DA.FetchLicensedVehicles();
        }
        public DataSet FetchCountries()
        {
            return this.DA.FetchCountries();
        }
        public DataSet FetchContractTypes()
        {
            return this.DA.FetchContractTypes();
        }

        public DataSet GetInstructorsById(string InstructorId)
        {
            DAInstructor instructor = new DAInstructor();
            return instructor.GetInstructorById(InstructorId);
        }
        public DataSet IsInactiveLanguage(string id)
        {
            DAInstructor instructor = new DAInstructor();
            return instructor.IsInactiveLanguage(id);
        }
        public DataSet IsInactiveVehicle(string id)
        {
            DAInstructor instructor = new DAInstructor();
            return instructor.IsInactiveVehicle(id);
        }
        public static DataSet GetDataSetForInstructor()
        {
            DataSet ds = new DataSet();

            DataTable dtInstructor = Entities.Instructor.GetDataTable();
            dtInstructor.Rows.Add(dtInstructor.NewRow());
            ds.Tables.Add(dtInstructor);

            DataTable dtInstructor_language = Entities.Instructor_Language.GetDataTable();
            ds.Tables.Add(dtInstructor_language);

            DataTable dtInstructor_Services = Entities.Instructor_Services.GetDataTable();
            ds.Tables.Add(dtInstructor_Services);

            DataTable dtInstructor_Service_Type = Entities.Instructor_Service_Type.GetDataTable();
            ds.Tables.Add(dtInstructor_Service_Type);

            DataTable dtInstructor_Availibity = Entities.Instructor_Availibility.GetDataTable();
            ds.Tables.Add(dtInstructor_Availibity);

            return ds;
        }

        public DataSet FetchWeekDays()
        {
            return this.DA.FetchWeekDays();
        }
        #endregion


        #region Validate Data
        public bool isUniqueEmployeeID(string data, string id)
        {
            return DA.isUniqueEmployeeID(data,id);
        }
        public bool isUniquePermitNo(string data, string id)
        {
            return DA.isUniquePermitNo(data,id);
        }
        public bool isUniquePassportNumber(string data, string id)
        {
            return DA.isUniquePassportNumber(data,id);
        }
        public bool isUniqueEmirateIDNumber(string data, string id)
        {
            return DA.isUniqueEmirateIDNumber(data,id);
        }
        
        #endregion

        #region SAVE
        public Int64 Save(DataSet ds, DbTransaction transaction)
        {
            DAInstructor oDAInstructor = new DAInstructor();
            return oDAInstructor.SaveInstructor(transaction, ds);
        }
        #endregion

        public string GetInstructorImage(string instructorId)
        {

            DataTable dt = new DataTable();
            var newInst = new DAInstructor();
            dt = newInst.GetInstructorImage(instructorId);
            if (dt.Rows.Count > 0)
            {
                string name = dt.Rows[0]["IMAGE"].ToString();
                return name;
            }
            else
                return "";

        }
    }
}

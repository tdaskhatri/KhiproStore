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
    public class Persons
    {


        public DataSet Search(Dictionary<Enumaration.SearchPersonsCriteria, Object> criteria, int pageToRetrieve, String orderBy)
        {
            DataSet ds = new DataSet();
            DAPersons oDa = new DAPersons();
            ds = oDa.Search(criteria, pageToRetrieve, orderBy,Enumaration.RecordsPerPage);

            return ds;
        }
        public DataSet GetPersonById(string id)
        {
            DAPersons oDa = new DAPersons();
            return oDa.GetPersonById(id);

        }
        public void Persist(DataSet ds )
        {

            DAPersons person = new DAPersons();
            
            
            using (DbTransaction transaction = person.CreateTransaction())
            {
                try
                {
                    DataTable dtPerson = ds.Tables[Entities.Persons.TABLE_NAME];

                    person.SavePersons(transaction, dtPerson.Rows[0]);
                    person.CommitTransaction(transaction);
                }
                catch (Exception e)
                {
                    person.RollbackTransaction(transaction);
                    throw e;
                }
            }

        
        }

    }
}


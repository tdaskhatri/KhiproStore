using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eLearning.DAL.DataAccess;
using System.Data;
namespace eLearning.DAL.DAClasses
{
    public sealed  class SystemNumber
    {
        private static volatile SystemNumber instance = null;
        private static readonly object syncRoot = new Object();
        private  SystemNumber(){ }
        public  static SystemNumber GetInstance()
        { 
           
          if(  instance == null )
          {
              lock (syncRoot)
              {
                  instance = new SystemNumber();
              }
          }
          return instance;
        }

        public string GetNextSystemNumber(string argument)
        {

            try
            {
                System.Threading.Monitor.Enter(this);
                
                Entities.SP_USP_GenerateSystemNumber sp = new  Entities.SP_USP_GenerateSystemNumber(argument);
                IdentityManager im = new IdentityManager();
                DataSet ds = im.ExecuteStoredProcedure("usp_GenerateSystemNumber", sp.ParamsList);
                return ds.Tables[0].Rows[0][0].ToString();
            
            }
            catch (Exception ex)
            {

            }
            finally
            {
                System.Threading.Monitor.Exit(this);
            }
            return null;
        
        }
    }
}

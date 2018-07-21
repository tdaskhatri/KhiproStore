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
    public class MysteryImport
    {
        public DataSet Save(DataSet ds,string phase,string year,string createdBy)
        {
            DACultureResources oDACultureRes = new DACultureResources();
            Entities.SP_USP_ImportMysteryShopper objSP = new Entities.SP_USP_ImportMysteryShopper(createdBy, phase, year, ds.GetXml());
            DataSet dsMysteryShopperHeader = oDACultureRes.ExecuteStoredProcedure(Entities.SP_USP_ImportMysteryShopper.SP_NAME, objSP.ParamsList);
            return dsMysteryShopperHeader;

       }

        public DataSet GetMysteryShopperById(string mysteryShopperId )
        {
            DACultureResources oDACultureRes = new DACultureResources();
            Entities.SP_USP_GetMysteryShopperById usp = new Entities.SP_USP_GetMysteryShopperById(mysteryShopperId.ToString());
            DataSet ds = oDACultureRes.ExecuteStoredProcedure(Entities.SP_USP_GetMysteryShopperById.SP_NAME, usp.ParamsList);
            ds.Tables[0].TableName = Entities.MysteryShopperHeader.TABLE_NAME;
            ds.Tables[1].TableName = Entities.MysteryShopperData.TABLE_NAME;
            return ds;
        }

        public static DataSet GetPageDataSet()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(Entities.MysteryShopperHeader.GetDataTable());
            ds.Tables[Entities.MysteryShopperHeader.TABLE_NAME].Rows.Add(ds.Tables[Entities.MysteryShopperHeader.TABLE_NAME].NewRow());

            return ds;
        }

    }
    
}

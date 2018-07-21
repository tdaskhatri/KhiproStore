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
    public class Rooms
    {
        DATrainingRooms objDARooms = null;



        
        public DataSet GetRoomsById(string id)
        {
            DataSet dsReturn = new DataSet();
            objDARooms = new DATrainingRooms();
            dsReturn = objDARooms.GetRoomById(id);
            return  dsReturn;
        }
        public void Save( DataSet ds )
        {
            objDARooms = new DATrainingRooms();
            DACultureResources oDACr = new DACultureResources();
            using (DbTransaction transaction = objDARooms.CreateTransaction())
            {
                try
                {
                    DataTable dtRoom = ds.Tables[Entities.TrainingRooms.TABLE_NAME];
                    DataRow room = dtRoom.Rows[0];
                    
                    //Saving culture resources for slide name:Start
                    
                    DataTable dtCr = ds.Tables[Entities.CultureResources.TABLE_NAME];
                    oDACr.PersistCultureResource(dtCr, transaction);
                    room[Entities.TrainingRooms.ROOM_NAME] = (Int64)dtCr.Rows[0][Entities.CultureResources.ID];
                    
                    //Saving culture resources for slide name:Finish
            
                    objDARooms.Save(transaction,room);
                    objDARooms.CommitTransaction(transaction);
                }
                catch (Exception e)
                {
                    objDARooms.RollbackTransaction(transaction);
                    throw e;
                }
            }
        }

        public static DataSet GetRoomDataSet()
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add(Entities.TrainingRooms.GetDataTable());
            DataTable dt = Entities.CultureResources.GetDataTable();
            dt.Rows.Add(dt.NewRow());
            dsReturn.Tables.Add(dt);
            return dsReturn;
          
        }
      
    }
}

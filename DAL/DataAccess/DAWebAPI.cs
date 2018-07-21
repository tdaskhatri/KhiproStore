using eLearning.Common.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace eLearning.DAL.DataAccess
{
    public class DAWebAPI : DABase
    {
        private string MODULE_NAME = "DAWebAPI.cs";
        private Logger logger = Logger.getInstance();
        public DataTable GetOffers(string OfferType)
        {
            try
            {
                string query = @"SELECT TITLE, SUMMARY, DETAIL FROM WP_OFFER_CONTENT WHERE IS_ACTIVE = 1
                                AND OFFER_TYPE = '{0}';";
                return ExecuteDataSet(string.Format(query, OfferType)).Tables[0];
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "GetOffers", ex);
                throw ex;
            }
        }
        public DataTable GetAllOffers(string OfferType)
        {
            try
            {
                string query = @"SELECT TOP 100 ID, TITLE, SUMMARY, DETAIL, OFFER_IMAGE FROM WP_OFFER_CONTENT WHERE IS_ACTIVE = 1
                                AND OFFER_TYPE = '{0}' ORDER BY CREATED_ON DESC;";
                return ExecuteDataSet(string.Format(query, OfferType)).Tables[0];
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "GetOffers", ex);
                throw ex;
            }
        }
        public DataTable GetOfferById(string OfferId)
        {
            try
            {
                string query = @"SELECT ID, OFFER_TYPE, TITLE, SUMMARY, DETAIL, OFFER_IMAGE FROM WP_OFFER_CONTENT WHERE ID = '{0}';";
                return ExecuteDataSet(string.Format(query, OfferId)).Tables[0];
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "GetOffers", ex);
                throw ex;
            }
        }



        public DataSet GetAllOffersExt()
        {
            try
            {
                string query = @"SELECT  ID, TITLE, SUMMARY, DETAIL, IS_ACTIVE, OFFER_TYPE, OFFER_IMAGE, CREATED_ON FROM WP_OFFER_CONTENT ORDER BY CREATED_ON DESC;";
                return ExecuteDataSet(query);
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "GetOffers", ex);
                throw ex;
            }
        }
        public DataSet GetOfferByIdExt(int OfferId)
        {
            try
            {
                string query = @"SELECT ID, OFFER_TYPE, TITLE, SUMMARY, DETAIL, OFFER_IMAGE, IS_ACTIVE, OFFER_TYPE FROM WP_OFFER_CONTENT WHERE ID = '{0}';";
                return ExecuteDataSet(string.Format(query, OfferId));
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "GetOfferByIdExt", ex);
                throw ex;
            }
        }

        public void InsertOffer(string type, string title, string summary, string detail, bool isActive, string image)
        {
            try
            {
                string query = @"
                    INSERT INTO [dbo].[WP_OFFER_CONTENT]
                               ([TITLE]
                               ,[SUMMARY]
                               ,[DETAIL]
                               ,[OFFER_TYPE]
                               ,[IS_ACTIVE]
                               ,[CREATED_ON]
                               ,[OFFER_IMAGE])
                         VALUES
                               ('{0}' --<TITLE, varchar(500),>
                               ,'{1}' --<SUMMARY, varchar(max),>
                               ,'{2}' --<DETAIL, varchar(max),>
                               ,'{3}' --<OFFER_TYPE, varchar(10),>
                               ,{4} --<IS_ACTIVE, bit,>
                               ,getdate() --<CREATED_ON, datetime,>
                               ,'{5}' --<OFFER_IMAGE, varchar(max),>)
                    ";
                ExecuteNonQuery(string.Format(query, title, summary, detail, type, (isActive ? '1' : '0'), image));
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "InsertOffer", ex);
                throw ex;
            }
        }

        public void UpdateOffer(string id, string type, string title, string summary, string detail, bool isActive, string image)
        {
            try
            {
                string query = @"

                 UPDATE [dbo].[WP_OFFER_CONTENT]
                   SET [TITLE] = '{0}'   --<TITLE, varchar(500),>
                      ,[SUMMARY] = '{1}' --<SUMMARY, varchar(max),>
                      ,[DETAIL] = '{2}'  --<DETAIL, varchar(max),>
                      ,[OFFER_TYPE] = '{3}'--<OFFER_TYPE, varchar(10),>
                      ,[IS_ACTIVE] = '{4}'--<IS_ACTIVE, bit,>
                      ,[OFFER_IMAGE] = '{5}'--<OFFER_IMAGE, varchar(max),>
                 WHERE id = {6};

                    ";
                ExecuteNonQuery(string.Format(query, title, summary, detail, type, (isActive ? '1' : '0'), image, id));
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "UpdateOffer", ex);
                throw ex;
            }
        }

    }
}

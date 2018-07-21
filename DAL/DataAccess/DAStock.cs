using eLearning.Common.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace eLearning.DAL.DataAccess
{
   public class DAStock :DABase
    {
        Logger logger = Logger.getInstance();
        string MODULE_NAME = "DAStock";

        string QRY_ADD_STOCK = @"INSERT INTO WAREHOUSE_STOCK(NAME,MEASURE_TYPE,CREATED_ON)
                                VALUES('{0}',{1},GETDATE())  SELECT SCOPE_IDENTITY()";

        string QRY_ADD_STOCK_PRICE = @"INSERT INTO STOCK_PRICE(STOCK_ID,PURCHASE_PRICE,SELL_PRICE_RETAIL,SELL_PRICE_WHOLE_SALE)
                                       VALUES({0},{1},{2},{3})";

        string QRY_ADD_STOCK_TRANSACTIONS= @"INSERT INTO WAREHOUSE_STOCK_TRANSACTIONS(STOCK_ID,QUANTITY,TOTAL_AMOUNT,
                                             AMOUNT_PAID,AMOUNT_DUE,MEASURE_TYPE,SUPPLIER_ID,CREATED_ON)
                                             VALUES('{0}',{1},{2},{3},{4},{5},{6},GETDATE())";

        string QRY_GET_SYS_STOCK = @"SELECT ID,NAME FROM WAREHOUSE_STOCK";

        string QRY_CHECK_STOCK_EXIST = @"SELECT COUNT(*) FROM STOCK WHERE NAME ='{0}'";
        string QRY_GET_SYS_SUPPLIER = "SELECT ID,SUPPLIER_NAME FROM SUPPLIER";

        string QRY_ADD_SUPPLIER = @"INSERT INTO SUPPLIER(SUPPLIER_NAME,PHONE)VALUES('{0}','{1}')";

        string QRY_INSERT_SALE_TRANSACTION = @"INSERT INTO SALE_TRANSACTION (CUSTOMER_ID_ID,CREATED_ON,TOTAL_AMOUNT,AMOUNT_PAID)
                                               VALUES({0},GETDATE(),{1},{2}) SELECT SCOPE_IDENTITY()";

        string QRY_INSERT_SALE_TRANSACTION_DETAIL = @"INSERT INTO SALE_TRANSACTION_DETAIL (SALE_TRANSACTION_ID,STOCK_ID,QUANTITY,MEASURE_TYPE_ID,AMOUNT,CREATED_ON)
                                                      VALUES({0},{1},{2},{3},{4},GETDATE());";

        string QRY_GET_SALE_STOCK_PRICE = @"SELECT SELL_PRICE_RETAIL FROM STOCK_PRICE WHERE STOCK_ID ={0}";

        String QRY_UPDATE_WAREHOUSE_STOCK_QUANTITY = @"UPDATE WAREHOUSE_STOCK_QUANTITY SET CURRENT_QUANTITY =ISNULL(CURRENT_QUANTITY,0)+{0}
                                                        WHERE STOCK_ID ={1}";

        public bool CheckStockExist(string Stockname)
        {
            string query = string.Format(QRY_CHECK_STOCK_EXIST, Stockname);
            int count = (int)ExecuteScalar(query);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void AddStock(DataTable dt)
        {
            try
            {
                string query = string.Format(QRY_ADD_STOCK, dt.Rows[0]["NAME"].ToString(),
                                                           dt.Rows[0]["STOCK_TYPE"].ToString());
                 var value = ExecuteScalar(query);
                 int Stock_id = Convert.ToInt32(value);


                query = string.Format(QRY_ADD_STOCK_PRICE, Stock_id,
                                                           dt.Rows[0]["PURCHASE_PRICE"].ToString(),
                                                           dt.Rows[0]["SELL_PRICE_RETAIL"].ToString(),
                                                           dt.Rows[0]["SELL_PRICE_WHOLE_SALE"].ToString());
                ExecuteNonQuery(query);

            }
            catch(Exception ex)
            {
                logger.Error(MODULE_NAME, "AddStock", ex);
            }
        }

        public DataTable GetStock()
        {
            try
            {

                return ExecuteDataSet(QRY_GET_SYS_STOCK).Tables[0];
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "AddStock", ex);
                throw ex;
            }
        }

        public DataTable GetSupplier()
        {
            try
            {

                return ExecuteDataSet(QRY_GET_SYS_SUPPLIER).Tables[0];
            }
            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "AddStock", ex);
                throw ex;
            }
        }


   public void AddStockTransactions(DataTable dt)
   {
            System.Data.Common.DbTransaction dbTran = CreateTransaction();

            try
            {


                string query = string.Format(QRY_ADD_STOCK_TRANSACTIONS, dt.Rows[0]["STOCK_ID"].ToString()
                                                                   , dt.Rows[0]["QUANTITY"].ToString()
                                                                   , dt.Rows[0]["TOTAL_AMOUNT"].ToString()
                                                                   , dt.Rows[0]["AMOUNT_PAID"].ToString()
                                                                   , dt.Rows[0]["AMOUNT_DUE"].ToString()
                                                                   , dt.Rows[0]["MEASURE_TYPE"].ToString()
                                                                   , dt.Rows[0]["SUPPLIER_ID"].ToString());
                ExecuteNonQuery(query,dbTran);

                query = string.Format(QRY_UPDATE_WAREHOUSE_STOCK_QUANTITY, Convert.ToInt32(dt.Rows[0]["QUANTITY"].ToString()),
                                                                          Convert.ToInt32(dt.Rows[0]["STOCK_ID"].ToString()));
                ExecuteNonQuery(query, dbTran);
                CommitTransaction(dbTran);
            }
            catch(Exception ex)
            {
                logger.Error(MODULE_NAME, "AddStockTransactions", ex);
                RollbackTransaction(dbTran);
                throw ex;
            }
   }

        public void AddSupplierName(DataTable dt)
        {
            string query = string.Format(QRY_ADD_SUPPLIER, dt.Rows[0]["SUPPLIER_NAME"].ToString()
                                                                   , dt.Rows[0]["PHONE"].ToString());
            ExecuteNonQuery(query);
        }

        public void AddSaleTransaction(DataTable SaleDetail, DataTable Sale)
        {
            System.Data.Common.DbTransaction dbTran = CreateTransaction();
            string SaleTransactionDetail = string.Empty;
            try
            {
                string query = string.Format(QRY_INSERT_SALE_TRANSACTION, Sale.Rows[0]["CUSTOMER_ID_ID"].ToString(),
                                                                         Sale.Rows[0]["TOTAL_AMOUNT"].ToString(),
                                                                         Sale.Rows[0]["AMOUNT_PAID"].ToString());
                var ID = ExecuteScalar(query,dbTran);
                int SaleTrnsactionId = Convert.ToInt32(ID);

                foreach(DataRow dr in SaleDetail.Rows)
                {
                    SaleTransactionDetail += string.Format(QRY_INSERT_SALE_TRANSACTION_DETAIL, SaleTrnsactionId,
                                                                                            dr["STOCK_ID"].ToString(),
                                                                                            dr["QUANTITY"].ToString(),
                                                                                            dr["MEASURE_TYPE"].ToString(),
                                                                                            dr["AMOUNT"].ToString());
                }
                ExecuteNonQuery(SaleTransactionDetail, dbTran);
                CommitTransaction(dbTran);
            }
            catch(Exception ex)
            {
                logger.Error(MODULE_NAME, "AddSaleTransaction", ex);
                RollbackTransaction(dbTran);
                throw ex;
            }
        }
        public decimal GetStockSalePrice(int StockId)
        {
            var amount = ExecuteScalar(string.Format(QRY_GET_SALE_STOCK_PRICE, StockId));
            return Convert.ToDecimal(amount);
        }


    }
}

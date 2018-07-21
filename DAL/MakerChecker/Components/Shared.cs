using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace eLearning.DAL.MakerChecker
{
    public static class Shared
    {
        public static string DATE_TIME_FORMAT = @"yyyy-MM-dd HH:mm:ss";
        public static string TIME_FORMAT = @"hh\:mm\:ss";
        public static string GetInsertQueryForInterim(DataRow row)
        {
            string tableName = Shared.GetTableName(row) + "_INTERIM";
            string columns = Shared.GetColumnCSV(row) + ", [Sys_OnApprove], [Sys_Status], [Sys_RequestId]";
            string values = Shared.GetValuesCSV(row) + ", " + ((int)OnApproveAction.Add) + ", " + ((int)InterimStatus.Pending) + ", @requestId";

            return String.Format(Templates.INSERT, tableName, columns, values);
        }

        public static string GetUpdateQueryForInterim(DataRow row, OnApproveAction action)
        {
            string tableName = Shared.GetTableName(row) + "_INTERIM";
            string setValues = Shared.GetSetValuesCSV(row) + ", [Sys_Status] = " + ((int)InterimStatus.Pending) + ", [Sys_RequestId] =  @requestId";
            string setValues2 = Shared.GetSetValuesCSV(row) + ", [Sys_OnApprove] = " + ((int)action) + ", [Sys_Status] = " + ((int)InterimStatus.Pending) + ", [Sys_RequestId] =  @requestId";
            string whereClause = Shared.GetWhereClause(row);

            string withAction = String.Format(Templates.UPDATE, tableName, setValues2, whereClause);
            string withoutAction = String.Format(Templates.UPDATE, tableName, setValues, whereClause);

            return String.Format(Templates.UPDATE_CONDITIONAL, tableName, whereClause, withoutAction, withAction);
        }

        public static string GetInsertQuery(DataRow row)
        {
            string template = @"INSERT INTO [{0}] ({1}) VALUES ({2});";
            string tableName = Shared.GetTableName(row);
            string columns = Shared.GetColumnCSV(row);
            string values = Shared.GetValuesCSV(row);

            return String.Format(template, tableName, columns, values);
        }

        public static string GetUpdateQuery(DataRow row)
        {
            string tableName = Shared.GetTableName(row);
            string setValues = Shared.GetSetValuesCSV(row);
            string whereClause = Shared.GetWhereClause(row);

            return String.Format(Templates.UPDATE, tableName, setValues, whereClause);
        }

        public static string GetDeleteQuery(DataRow row)
        {
            string tableName = Shared.GetTableName(row);
            string whereClause = Shared.GetWhereClause(row);

            return String.Format(Templates.DELETE, tableName, whereClause);
        }

        public static Script GetInsertApproval(DataTable table, int requestId)
        {
            Script script = new Script("APPROVING INSERTS FOR " + table.TableName);
            string defaultTable = table.TableName;
            string columns = Shared.GetColumnCSV(table);
            string interimTable = Shared.ToInterimTable(defaultTable);
            string sysSetValues = Shared.GetSysSetValues(InterimStatus.Approved, OnApproveAction.None);
            string sysWhereClause = Shared.GetSysWhereClause(InterimStatus.Pending, OnApproveAction.Add, requestId);

            script += String.Format(Templates.INSERT_BULK, columns, defaultTable, interimTable, sysWhereClause);
            script += String.Format(Templates.UPDATE, interimTable, sysSetValues, sysWhereClause);

            return script;
        }

        public static Script GetUpdateApproval(DataTable table, int requestId)
        {
            Script script = new Script("APPROVING UPDATES FOR " + table.TableName);
            string defaultTable = table.TableName;
            string columnSets = Shared.GetCopyValuesCSV(table, "B");
            string interimTable = Shared.ToInterimTable(defaultTable);
            string pkColumnName = Shared.GetPKColumnName(table);
            string sysSetValues = Shared.GetSysSetValues(InterimStatus.Approved, OnApproveAction.None);
            string sysWhereClause = Shared.GetSysWhereClause(InterimStatus.Pending, OnApproveAction.Update, requestId);
            string sysWhereClause2 = Shared.GetSysWhereClause(InterimStatus.Pending, OnApproveAction.Update, requestId, "B");

            script += String.Format(Templates.UPDATE_BULK, defaultTable, columnSets, interimTable, pkColumnName, sysWhereClause2);
            script += String.Format(Templates.UPDATE, interimTable, sysSetValues, sysWhereClause);

            return script;
        }

        public static Script GetDeleteApproval(DataTable table, int requestId)
        {
            Script script = new Script("APPROVING DELETIONS FOR " + table.TableName);
            string defaultTable = table.TableName;
            string interimTable = Shared.ToInterimTable(defaultTable);
            string pkColumnName = Shared.GetPKColumnName(table);
            string sysWhereClause = Shared.GetSysWhereClause(InterimStatus.Pending, OnApproveAction.Delete, requestId);

            script += String.Format(Templates.DELETE_BULK, defaultTable, pkColumnName, interimTable, sysWhereClause);
            script += String.Format(Templates.DELETE, interimTable, sysWhereClause);

            return script;
        }

        public static Script GetRejection(DataTable table, int requestId)
        {
            Script script = new Script();
            string defaultTable = table.TableName;
            string interimTable = Shared.ToInterimTable(defaultTable);
            string sysSetValues = Shared.GetSysSetValues(InterimStatus.Rejected);
            string sysWhereClause = Shared.GetSysWhereClause(InterimStatus.Pending, requestId);

            script += String.Format(Templates.UPDATE, interimTable, sysSetValues, sysWhereClause);

            return script;
        }

        public static DataColumn GetPKColumn(DataRow row)
        {
            return row.Table.Columns[0];
        }

        public static string GetPKColumnName(DataTable table)
        {
            return table.Columns[0].ColumnName;
        }

        public static string GetTableName(DataRow row)
        {
            if (String.IsNullOrWhiteSpace(row.Table.TableName))
                throw new Exception("Table Name is not available!");

            return row.Table.TableName;
        }

        private static string GetColumnCSV(DataRow row)
        {
            return GetColumnCSV(row.Table);
        }

        private static string GetColumnCSV(DataTable table)
        {
            string columns = String.Empty;

            foreach (DataColumn column in table.Columns)
                if (column.GetIgnored() == false)
                {
                    columns += (columns == String.Empty ? String.Empty : ",") + "[" + column.ColumnName + "]";
                }

            return columns;
        }

        private static string GetValuesCSV(DataRow row)
        {
            DataTable table = row.Table;
            string values = String.Empty;
            string columnPostfix = string.Empty;


            foreach (DataColumn column in table.Columns)
                if (column.GetIgnored() == false)
                {
                    object data = Shared.GetData(row, column);

                    if (data == null || data == DBNull.Value)
                    {
                        values += (values == String.Empty ? String.Empty : ",") + "NULL";
                    }
                    else
                    {
                        if (column.DataType == typeof(Byte[]))
                        {
                            var base64 = Convert.ToBase64String((Byte[])data);
                            values += (values == String.Empty ? String.Empty : ",") + "'" + base64 + "'";
                        }
                        else if (column.DataType == typeof(DateTime))
                        {
                            values += (values == String.Empty ? String.Empty : ",") + "CONVERT(datetime, '" + Convert.ToDateTime(data).ToString(Shared.DATE_TIME_FORMAT) + "', 120)";
                        }
                        else if (column.DataType == typeof(TimeSpan))
                        {
                            values += (values == String.Empty ? String.Empty : ",") + "CONVERT(time(1), '" + ((TimeSpan)data).ToString(Shared.TIME_FORMAT) + "')";
                        }
                        else if (column.DataType == typeof(string))
                        {
                            if (IsUnicodeColumn(column))
                            {
                                columnPostfix = "N";
                            }
                            values += (values == String.Empty ? String.Empty : ",") + columnPostfix + "'" + Convert.ToString(data).Replace("'", "''") + "'";
                        }
                        else if (column.DataType == typeof(bool))
                        {
                            values += (values == String.Empty ? String.Empty : ",") + (Convert.ToBoolean(data) == true ? "1" : "0");
                        }
                        else
                        {
                            values += (values == String.Empty ? String.Empty : ",") + Convert.ToString(data);
                        }
                    }
                }

            return values;
        }

        private static string GetParametersCSV(DataRow row)
        {
            return GetParametersCSV(row.Table);
        }

        private static string GetParametersCSV(DataTable table)
        {
            string columns = String.Empty;

            foreach (DataColumn column in table.Columns)
                if (column.GetIgnored() == false)
                {
                    columns += (columns == String.Empty ? String.Empty : ",") + ToParameterName(column.ColumnName);
                }

            return columns;
        }

        private static string GetSetValuesCSV(DataRow row)
        {
            DataTable table = row.Table;
            string values = String.Empty;
            string columnPostfix = string.Empty;

            foreach (DataColumn column in table.Columns)
                if (column.GetIgnored() == false)
                {
                    String columnName = @"[" + column.ColumnName + "]";
                    object data = Shared.GetData(row, column);

                    if (data == null || data == DBNull.Value)
                    {
                        values += (values == String.Empty ? String.Empty : ",") + columnName + " = " + "NULL";
                    }
                    else
                    {
                        if (column.DataType == typeof(Byte[]))
                        {
                            var base64 = Convert.ToBase64String((Byte[])data);
                            values += (values == String.Empty ? String.Empty : ",") + columnName + " = " + "'" + base64 + "'";
                        }
                        else if (column.DataType == typeof(DateTime))
                        {
                            values += (values == String.Empty ? String.Empty : ",") + columnName + " = " + "CONVERT(datetime, '" + Convert.ToDateTime(data).ToString(Shared.DATE_TIME_FORMAT) + "', 120)";
                        }
                        else if (column.DataType == typeof(TimeSpan))
                        {
                            values += (values == String.Empty ? String.Empty : ",") + "CONVERT(time(1), '" + ((TimeSpan)data).ToString(Shared.TIME_FORMAT) + "')";
                        }
                        else if (column.DataType == typeof(string))
                        {
                            if (IsUnicodeColumn(column))
                            {
                                columnPostfix = "N";
                            }

                            values += (values == String.Empty ? String.Empty : ",") + columnName + " = " + columnPostfix + "'" + Convert.ToString(data).Replace("'", "''") + "'";
                        }
                        else if (column.DataType == typeof(bool))
                        {
                            values += (values == String.Empty ? String.Empty : ",") + columnName + " = " + (Convert.ToBoolean(data) ? 1 : 0);
                        }
                        else
                        {
                            values += (values == String.Empty ? String.Empty : ",") + columnName + " = " + Convert.ToString(data);
                        }
                    }
                }

            return values;
        }

        private static string GetCopyValuesCSV(DataTable table, string sourceAlias)
        {
            string values = String.Empty;

            foreach (DataColumn column in table.Columns)
                if (column.GetIgnored() == false)
                {
                    String columnName = @"[" + column.ColumnName + "]";

                    values += (values == String.Empty ? String.Empty : ",") + columnName + " = " + sourceAlias + "." + columnName;
                }

            return values;
        }

        private static string GetWhereClause(DataRow row)
        {
            DataTable table = row.Table;
            string clause = String.Empty;
            string columnPostfix = string.Empty;

            DataColumn column = Shared.GetPKColumn(row);

            object data = Shared.GetData(row, column);

            if (data == null)
            {
                clause += column.ColumnName + " IS " + "NULL";
            }
            else
            {
                if (column.DataType == typeof(DateTime))
                {
                    clause += column.ColumnName + " = " + "CONVERT(datetime, '" + Convert.ToDateTime(data).ToString(Shared.DATE_TIME_FORMAT) + "', 120)";
                }
                else if (column.DataType == typeof(TimeSpan))
                {
                    clause += column.ColumnName + " = " + "CONVERT(time(1), '" + ((TimeSpan)data).ToString(Shared.TIME_FORMAT) + "')";
                }
                else if (column.DataType == typeof(string))
                {
                    if (IsUnicodeColumn(column))
                    {
                        columnPostfix = "N";
                    }
                    clause += column.ColumnName + " = " + columnPostfix + "'" + Convert.ToString(data) + "'";
                }
                else
                {
                    clause += column.ColumnName + " = " + Convert.ToString(data);
                }
            }

            return clause;
        }

        private static string GetSysWhereClause(InterimStatus status, int requestId)
        {
            string whereClause = String.Format("[Sys_Status] = {0} AND [Sys_RequestId] = {1}",
                                   ((int)status), requestId);
            return whereClause;
        }

        private static string GetSysWhereClause(InterimStatus status, OnApproveAction action, int requestId)
        {
            string whereClause = String.Format("[Sys_Status] = {0} AND [Sys_OnApprove] = {1} AND [Sys_RequestId] = {2}",
                                   ((int)status), ((int)action), requestId);
            return whereClause;
        }

        private static string GetSysWhereClause(InterimStatus status, OnApproveAction action, int requestId, string alias)
        {
            string prefix = (String.IsNullOrWhiteSpace(alias) ? "" : alias + ".");
            string whereClause = String.Format("{3}[Sys_Status] = {0} AND {3}[Sys_OnApprove] = {1} AND {3}[Sys_RequestId] = {2}",
                                   ((int)status), ((int)action), requestId, prefix);
            return whereClause;
        }

        private static string GetSysSetValues(InterimStatus status, OnApproveAction action)
        {
            string setStatements = String.Format("[Sys_Status] = {0}, [Sys_OnApprove] = {1}", ((int)status), ((int)action));
            return setStatements;
        }

        private static string GetSysSetValues(InterimStatus status)
        {
            string setStatements = String.Format("[Sys_Status] = {0}", ((int)status));
            return setStatements;
        }

        private static string ToInterimTable(string tableName)
        {
            return tableName + "_INTERIM";
        }

        private static string ToParameterName(string columnName)
        {
            return "@" + columnName.Replace(" ", "_");
        }

        private static object GetData(DataRow row, DataColumn column)
        {
            if (row.RowState == DataRowState.Deleted)
            {
                return row[column, DataRowVersion.Original];
            }
            else
            {
                return row[column];
            }
        }

        //Updated by Fahim Nasir return true in every case to insert arabic.
        //Added by M.Tariq on 06 Jan. 2017 to recognize unicode columns 

        private static bool IsUnicodeColumn(DataColumn column)
        {
            return true;
            //if (column.ColumnName.Trim().Contains("_AR") || column.ColumnName.Trim().Contains("_ar"))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

    }
}

using System;
using System.Data;
using System.Data.OracleClient;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace Yamaya
{
    public class BYamaya
    {
        #region Constant
        public const string TAB_KEY_AREA      = "AREA";
        public const string TAB_KEY_STORE     = "STORE";
        public const string TAB_KEY_CATEGORY  = "CATEGORY";
        public const string TAB_KEY_ITEM      = "ITEM";
        public const string TAB_KEY_ITEM_DESC = "ITEM_DESC"; 
        #endregion

        #region Declaration

        private bool area_mapping = false;
        private bool item_mapping = false;
        private bool item_des_mapping = false;
        private bool store_mapping    = false;
        #endregion

        #region Get DataTable Value

        public DataTable getAreaDT(string DBConnection)
        {
            IDbConnection iConn = new OracleConnection(DBConnection);
            iConn.Open();

            try
            {
                DataTable dt = executeDataTable(iConn, CommandType.Text, YamayaStmt.GET_AREA_DATA, (IDbDataParameter[])null);
                dt.TableName = TAB_KEY_AREA;
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                iConn.Close();
            }
        }

        public DataTable getCategoryDT(string DBConnection)
        {
            IDbConnection iConn = new OracleConnection(DBConnection);
            iConn.Open();

            try
            {
                DataTable dt = executeDataTable(iConn, CommandType.Text, YamayaStmt.GET_CATEGORY_DATA, (IDbDataParameter[])null);
                dt.TableName = TAB_KEY_CATEGORY;
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                iConn.Close();
            }
        }

        public DataTable getStoreDT(string DBConnection)
        {
            IDbConnection iConn = new OracleConnection(DBConnection);
            iConn.Open();

            try
            {
                DataTable dt = executeDataTable(iConn, CommandType.Text, YamayaStmt.GET_STORE_DATA, (IDbDataParameter[])null);
                dt.TableName = TAB_KEY_STORE;
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                iConn.Close();
            }
        }

        public DataTable getItemDT(string DBConnection)
        {
            IDbConnection iConn = new OracleConnection(DBConnection);
            iConn.Open();

            try
            {
                DataTable dt = executeDataTable(iConn, CommandType.Text, YamayaStmt.GET_ITEM_DATA, (IDbDataParameter[])null);
                dt.TableName = TAB_KEY_ITEM;
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                iConn.Close();
            }
        }

        public DataTable getItemDescDT(string DBConnection)
        {
            IDbConnection iConn = new OracleConnection(DBConnection);
            iConn.Open();

            try
            {
                DataTable dt = executeDataTable(iConn, CommandType.Text, YamayaStmt.GET_ITEMDESC_DATA, (IDbDataParameter[])null);
                dt.TableName = TAB_KEY_ITEM_DESC;
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                iConn.Close();
            }
        } 

        #endregion

        #region Save DataTable Records
        public void saveRecords(Dictionary<string, DataTable> Dic, string DBConnection)
        {
            IDbConnection iConn = new OracleConnection(DBConnection);
            iConn.Open();
            IDbTransaction iTran = iConn.BeginTransaction();

            DataTable dtArea     = null;
            DataTable dtCategory = null;
            DataTable dtStore    = null;
            DataTable dtItem     = null;
            DataTable dtItemDesc = null;

            try
            {
                if (Dic.ContainsKey(TAB_KEY_AREA) == true)
                {
                    dtArea = Dic[TAB_KEY_AREA];
                    saveAreaRecords(dtArea, iTran);
                }

                if (Dic.ContainsKey(TAB_KEY_STORE) == true)
                {
                    dtStore = Dic[TAB_KEY_STORE];
                    saveStoreRecords(dtStore, iTran);
                }

                if (Dic.ContainsKey(TAB_KEY_CATEGORY) == true)
                {
                    dtCategory = Dic[TAB_KEY_CATEGORY];
                    saveCatogoryRecords(dtCategory, iTran);
                }

                if (Dic.ContainsKey(TAB_KEY_ITEM) == true)
                {
                    dtItem = Dic[TAB_KEY_ITEM];
                    saveItemRecords(dtItem, iTran);
                }

                if (Dic.ContainsKey(TAB_KEY_ITEM_DESC) == true)
                {
                    dtItemDesc = Dic[TAB_KEY_ITEM_DESC];
                    saveItemDescRecords(dtItemDesc, iTran);
                }

                if (dtArea != null)
                {
                    UpdateAreaMapping(iTran);
                    dtArea.AcceptChanges();

                }

                if (dtStore != null)
                {
                    UpdateStoreMapping(iTran);
                    dtStore.AcceptChanges();
                }

                if (dtCategory != null)
                {
                    UpdateCategoryMapping(iTran);
                    dtCategory.AcceptChanges();
                }

                if (dtItem != null)
                {
                    UpdateItemMapping(iTran);
                    dtItem.AcceptChanges();

                }

                if (dtItemDesc != null)
                {
                    UpdateItemDescMapping(iTran);
                    dtItemDesc.AcceptChanges();
                }

                iTran.Commit();

            }
            catch (Exception ex)
            {
                iTran.Rollback();
                throw ex;
            }
            finally
            {
                iConn.Close();
            }
        }

        private void saveAreaRecords(DataTable dtArea, IDbTransaction iTran)
        {
            string stmt = string.Empty;

            foreach (DataRow dr in dtArea.Rows)
            {
                if (dr.RowState == DataRowState.Unchanged)
                    continue;

                string[] value = new string[7];
                value[0] = dr[0].ToString();
                value[1] = dr[1].ToString();
                value[2] = dr[2].ToString();
                value[3] = dr[3].ToString();
                value[4] = dr[4].ToString();
                value[5] = dr[5].ToString();
                value[6] = dr[6].ToString();

                if (dr.RowState == DataRowState.Added)
                {
                    stmt = string.Format(YamayaStmt.INS_AREA_DATA, value);
                    executeNonQuery(iTran, CommandType.Text, stmt, (IDbDataParameter[])null);
                }
                else if(dr.RowState == DataRowState.Modified)
                {
   
                    if (dr["REC_DELETED"] != DBNull.Value && ((Decimal)dr["REC_DELETED"]) == 1)
                    {
                        stmt = string.Format(YamayaStmt.DEL_AREA_DATA, value);
                        executeNonQuery(iTran, CommandType.Text, stmt, (IDbDataParameter[])null);
                    }
                    else
                    {
                        stmt = string.Format(YamayaStmt.UPD_AREA_DATA, value);
                        int i = executeNonQuery(iTran, CommandType.Text, stmt, (IDbDataParameter[])null);

                        if (i == 0)
                        {
                            stmt = string.Format(YamayaStmt.INS_AREA_DATA, value);
                            executeNonQuery(iTran, CommandType.Text, stmt, (IDbDataParameter[])null);
                        }
                    }
                }

           }
        }

        private void saveCatogoryRecords(DataTable dtCategory, IDbTransaction iTran)
        {
            string stmt = string.Empty;

            foreach (DataRow dr in dtCategory.Rows)
            {
                if (dr.RowState == DataRowState.Unchanged)
                    continue;

                string[] value = new string[3];
                value[0] = dr[0].ToString();
                value[1] = dr[1].ToString();
                value[2] = dr[2].ToString();

                if (dr.RowState == DataRowState.Added)
                {
                    stmt = string.Format(YamayaStmt.INS_CATEGORY_DATA, value);
                    executeNonQuery(iTran, CommandType.Text, stmt, (IDbDataParameter[])null);
                }
                else if (dr.RowState == DataRowState.Modified)
                {
                    if (dr["REC_DELETED"] != DBNull.Value && ((Decimal)dr["REC_DELETED"]) == 1)
                    {
                        stmt = string.Format(YamayaStmt.DEL_CATEGORY_DATA, value);
                        executeNonQuery(iTran, CommandType.Text, stmt, (IDbDataParameter[])null);
                    }
                    else
                    {
                        stmt = string.Format(YamayaStmt.UPD_CATEGROY_DATA, value);
                        int i = executeNonQuery(iTran, CommandType.Text, stmt, (IDbDataParameter[])null);

                        if (i == 0)
                        {
                            stmt = string.Format(YamayaStmt.INS_CATEGORY_DATA, value);
                            executeNonQuery(iTran, CommandType.Text, stmt, (IDbDataParameter[])null);
                        }
                    }
                }


            }
        }

        private void saveStoreRecords(DataTable dtStore, IDbTransaction iTran)
        {
            string stmt = string.Empty;

            foreach (DataRow dr in dtStore.Rows)
            {
                if (dr.RowState == DataRowState.Unchanged)
                    continue;

                string[] value = new string[3];
                value[0] = dr[0].ToString();
                value[1] = dr[1].ToString();
                value[2] = dr[2].ToString();

                if (dr.RowState == DataRowState.Added)
                {
                    stmt = string.Format(YamayaStmt.INS_STORE_DATA, value);
                    executeNonQuery(iTran, CommandType.Text, stmt, (IDbDataParameter[])null);
                }
                else if (dr.RowState == DataRowState.Modified)
                {
                    if (dr["REC_DELETED"] != DBNull.Value && ((Decimal)dr["REC_DELETED"]) == 1)
                    {
                        stmt = string.Format(YamayaStmt.DEL_STORE_DATA, value);
                        executeNonQuery(iTran, CommandType.Text, stmt, (IDbDataParameter[])null);
                    }
                    else
                    {
                        stmt = string.Format(YamayaStmt.UPD_STORE_DATA, value);
                        int i = executeNonQuery(iTran, CommandType.Text, stmt, (IDbDataParameter[])null);

                        if (i == 0)
                        {
                            stmt = string.Format(YamayaStmt.INS_STORE_DATA, value);
                            executeNonQuery(iTran, CommandType.Text, stmt, (IDbDataParameter[])null);
                        }
                    }
                }
            }
        }

        private void saveItemRecords(DataTable dtItem, IDbTransaction iTran)
        {
            string stmt = string.Empty;

            foreach (DataRow dr in dtItem.Rows)
            {
                if (dr.RowState == DataRowState.Unchanged)
                    continue;

                string[] value = new string[8];
                value[0] = dr[0].ToString();
                value[1] = dr[1].ToString();
                value[2] = dr[2].ToString();
                value[3] = dr[3].ToString();
                value[4] = dr[4].ToString();
                value[5] = dr[5].ToString();
                value[6] = dr[6].ToString();
                value[7] = dr[7].ToString();

                if (dr.RowState == DataRowState.Added)
                {
                    stmt = string.Format(YamayaStmt.INS_ITEM_DATA, value);
                    executeNonQuery(iTran, CommandType.Text, stmt, (IDbDataParameter[])null);
                }
                else if (dr.RowState == DataRowState.Modified)
                {
                    if (dr["REC_DELETED"] != DBNull.Value && ((Decimal)dr["REC_DELETED"]) == 1)
                    {
                        stmt = string.Format(YamayaStmt.DEL_ITEM_DATA, value);
                        executeNonQuery(iTran, CommandType.Text, stmt, (IDbDataParameter[])null);
                    }
                    else
                    {
                        stmt = string.Format(YamayaStmt.UPD_ITEM_DATA, value);
                        int i = executeNonQuery(iTran, CommandType.Text, stmt, (IDbDataParameter[])null);

                        if (i == 0)
                        {
                            stmt = string.Format(YamayaStmt.INS_ITEM_DATA, value);
                            executeNonQuery(iTran, CommandType.Text, stmt, (IDbDataParameter[])null);
                        }
                    }
                }
            }
        }

        private void saveItemDescRecords(DataTable dtItemDesc, IDbTransaction iTran)
        {
            string stmt = string.Empty;

            foreach (DataRow dr in dtItemDesc.Rows)
            {
                if (dr.RowState == DataRowState.Unchanged)
                    continue;

                string[] value = new string[4];
                value[0] = dr[0].ToString();
                value[1] = dr[1].ToString();
                value[2] = dr[2].ToString();
                value[3] = dr[3].ToString();

                if (dr.RowState == DataRowState.Added)
                {
                    stmt = string.Format(YamayaStmt.INS_ITEMDESC_DATA, value);
                    executeNonQuery(iTran, CommandType.Text, stmt, (IDbDataParameter[])null);
                }
                else if (dr.RowState == DataRowState.Modified)
                {
                    if (dr["REC_DELETED"] != DBNull.Value && ((Decimal)dr["REC_DELETED"]) == 1)
                    {
                        stmt = string.Format(YamayaStmt.DEL_ITEMDESC_DATA, value);
                        executeNonQuery(iTran, CommandType.Text, stmt, (IDbDataParameter[])null);
                    }
                    else
                    {
                        stmt = string.Format(YamayaStmt.UPD_ITEMDESC_DATA, value);
                        int i = executeNonQuery(iTran, CommandType.Text, stmt, (IDbDataParameter[])null);

                        if (i == 0)
                        {
                            stmt = string.Format(YamayaStmt.INS_ITEMDESC_DATA, value);
                            executeNonQuery(iTran, CommandType.Text, stmt, (IDbDataParameter[])null);
                        }
                    }
                }


            }
        } 

        #endregion

        #region Oracle SQL Function
        public DataTable executeDataTable(IDbConnection connection, CommandType commandType, string commandText, params IDbDataParameter[] commandParameters)
        {
            try
            {
                //create a command and prepare it for execution
                OracleCommand cmd = new OracleCommand();
                PrepareCommand(cmd, connection, (IDbTransaction)null, commandType, commandText, commandParameters);

                //create the DataAdapter & DataTable
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();

                //fill the DataTable using default values for DataTable names, etc.
                da.Fill(dt);

                // detach the SqlParameters from the command object, so they can be used again.			
                cmd.Parameters.Clear();

                //return the datatable
                return dt;
            }
            catch (Exception ex)
            {
                throw (new Exception(string.Concat(ex.Message.ToString(), "\r\nExecuted SQL Statement:\r\n", commandText.ToString()), ex));
            }
        }

        public DataTable executeDataTable(IDbTransaction transaction, CommandType commandType, string commandText, params IDbDataParameter[] commandParameters)
        {
            try
            {
                //create a command and prepare it for execution
                OracleCommand cmd = new OracleCommand();
                PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);

                //create the DataAdapter & DataTable
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();

                //fill the DataTable using default values for DataTable names, etc.
                da.Fill(dt);

                // detach the SqlParameters from the command object, so they can be used again.
                cmd.Parameters.Clear();

                //return the datatable
                return dt;
            }
            catch (Exception ex)
            {
                throw (new Exception(string.Concat(ex.Message.ToString(), "\r\nExecuted SQL Statement:\r\n", commandText.ToString()), ex));
            }
        }

        public int executeNonQuery(IDbTransaction transaction, CommandType commandType, string commandText, params IDbDataParameter[] commandParameters)
        {
            try
            {
                //create a command and prepare it for execution
                OracleCommand cmd = new OracleCommand();  
                PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);

                //finally, execute the command.
                int retval = cmd.ExecuteNonQuery();

                // detach the SqlParameters from the command object, so they can be used again.
                cmd.Parameters.Clear();
                return retval;
            }
            catch (Exception ex)
            {
                string errMsg = string.Concat(ex.Message.ToString(), "\r\nExecuted SQL Statement:\r\n", commandText.ToString()); ;
                throw (new Exception(errMsg, ex));
            }
        }

        private void PrepareCommand(IDbCommand command, IDbConnection connection, IDbTransaction transaction, CommandType commandType, string commandText, IDbDataParameter[] commandParameters)
        {
            //if the provided connection is not open, we will open it
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            //associate the connection with the command
            command.Connection = connection;

            //set the command text (stored procedure name or SQL statement)
            command.CommandText = commandText;

            //if we were provided a transaction, assign it.
            if (transaction != null)
            {
                command.Transaction = transaction;
            }

            //set the command type
            command.CommandType = commandType;

            //attach the command parameters if they are provided
            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }

            return;
        }

        private void AttachParameters(IDbCommand command, IDbDataParameter[] commandParameters)
        {
            foreach (OracleParameter p in commandParameters)
            {
                //check for derived output value with no value assigned
                if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
                {
                    p.Value = DBNull.Value;
                }

                command.Parameters.Add(p);
            }
        } 
        #endregion

        #region UpdateMappingTable

        public void UpdateAreaMapping(IDbTransaction iTran)
        {            
            string stmt   = YamayaStmt.UPD_AREA_MAPPING;
            executeNonQuery(iTran, CommandType.Text, stmt, (IDbDataParameter[])null);
        }

        public void UpdateStoreMapping(IDbTransaction iTran)
        {            
            string stmt   = YamayaStmt.UPD_STORE_SIZE_MAPPING;
            executeNonQuery(iTran, CommandType.Text, stmt, (IDbDataParameter[])null);
        }

        public void UpdateCategoryMapping(IDbTransaction iTran)
        {
            string stmt = YamayaStmt.UPD_ITEM_CAT_MAPPING1;
            executeNonQuery(iTran, CommandType.Text, stmt, (IDbDataParameter[])null);

            stmt = YamayaStmt.UPD_ITEM_CAT_MAPPING2;
            executeNonQuery(iTran, CommandType.Text, stmt, (IDbDataParameter[])null);

            stmt = YamayaStmt.UPD_ITEM_CAT_MAPPING3;
            executeNonQuery(iTran, CommandType.Text, stmt, (IDbDataParameter[])null);

        }

        public void UpdateItemMapping(IDbTransaction iTran)
        {
            string stmt   = YamayaStmt.UPD_ITEM_MAPPING;
            executeNonQuery(iTran, CommandType.Text, stmt, (IDbDataParameter[])null);
        }

        public void UpdateItemDescMapping(IDbTransaction iTran)
        {
            string stmt = YamayaStmt.UPD_ITEM_DESC_MAPPING1;
            executeNonQuery(iTran, CommandType.Text, stmt, (IDbDataParameter[])null);

            stmt = YamayaStmt.UPD_ITEM_DESC_MAPPING2;
            executeNonQuery(iTran, CommandType.Text, stmt, (IDbDataParameter[])null);

            stmt = YamayaStmt.UPD_ITEM_DESC_MAPPING3;
            executeNonQuery(iTran, CommandType.Text, stmt, (IDbDataParameter[])null);

            stmt = YamayaStmt.UPD_ITEM_DESC_MAPPING4;
            executeNonQuery(iTran, CommandType.Text, stmt, (IDbDataParameter[])null);

            stmt = YamayaStmt.UPD_ITEM_DESC_MAPPING5;
            executeNonQuery(iTran, CommandType.Text, stmt, (IDbDataParameter[])null);

            stmt = YamayaStmt.UPD_ITEM_DESC_MAPPING6;
            executeNonQuery(iTran, CommandType.Text, stmt, (IDbDataParameter[])null);

            stmt = YamayaStmt.UPD_ITEM_DESC_MAPPING7;
            executeNonQuery(iTran, CommandType.Text, stmt, (IDbDataParameter[])null);
        }

        #endregion
        
    }
}

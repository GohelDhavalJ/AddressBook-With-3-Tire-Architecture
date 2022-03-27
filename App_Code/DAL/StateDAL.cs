using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StateDAL
/// </summary>
public class StateDAL : DatabaseConfig
{
    #region Constuctor
    public StateDAL()
    {

    }
    #endregion Constuctor

    #region Local Variables

    protected string _Message;

    public string Message
    {
        get
        {
            return _Message;
        }
        set
        {
            _Message = value;
        }
    }

    #endregion Local Variables

    #region Insert
    public Boolean Insert(StateENT entState)
    {
        using (SqlConnection objConn = new SqlConnection(ConnectionString))
        {
            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();
            }
            using (SqlCommand objCmd = objConn.CreateCommand())
            {

                try
                {
                    #region Prepare Command
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "[dbo].[PR_State_InsertWithOutParameter]";
                    objCmd.Parameters.Add("@StateID", SqlDbType.Int,4).Direction = ParameterDirection.Output;
                    objCmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = entState.CountryID;
                    objCmd.Parameters.Add("@StateName", SqlDbType.VarChar).Value = entState.StateName;
                    objCmd.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = entState.Statecode;

                    
                    #endregion Prapare Command

                    objCmd.ExecuteNonQuery();

                    if (objCmd.Parameters["@StateID"] != null)
                    {
                        entState.StateID = Convert.ToInt32(objCmd.Parameters["@StateID"].Value);
                    }

                    return true;
                }
                catch (SqlException sqlex)
                {
                    Message = sqlex.Message;
                    return false;
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                    return false;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                    {
                        objConn.Close();
                    }
                }

            }
        }
    }
    #endregion Insert

    #region Update
    public Boolean Update(StateENT entState)
    {
        using (SqlConnection objConn = new SqlConnection(ConnectionString))
        {
            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();
            }
            using (SqlCommand objCmd = objConn.CreateCommand())
            {

                try
                {
                    #region Prepare Command
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "[dbo].[PR_State_UpdateByPK]";
                    objCmd.Parameters.AddWithValue("@StateID", entState.StateID);
                    objCmd.Parameters.AddWithValue("@CountryID", entState.CountryID);
                    objCmd.Parameters.AddWithValue("@StateName", entState.StateName);
                    objCmd.Parameters.AddWithValue("@StateCode", entState.Statecode);
                    #endregion Prapare Command

                    objCmd.ExecuteNonQuery();

                    return true;
                }
                catch (SqlException sqlex)
                {
                    Message = sqlex.Message;
                    return false;
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                    return false;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                    {
                        objConn.Close();
                    }
                }

            }
        }
    }

    #endregion Update

    #region Delete
    public Boolean DeleteState(SqlInt32 StateID)
    {
        using (SqlConnection objConn = new SqlConnection(ConnectionString))
        {
            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();
            }
            using (SqlCommand objCmd = objConn.CreateCommand())
            {

                try
                {
                    #region Prepare Command
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "[dbo].[PR_State_DeleteByPK]";
                    objCmd.Parameters.AddWithValue("@StateID", StateID);
                    #endregion Prepare Command

                    objCmd.ExecuteNonQuery();

                    return true;
                }
                catch (SqlException sqlex)
                {
                    Message = sqlex.Message;
                    return false;
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                    return false;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                    {
                        objConn.Close();
                    }
                }

            }
        }
    }

    #endregion Delete

    #region Select

    #region Select 
    public DataTable SelectAll()
    {
        using (SqlConnection objConn = new SqlConnection(ConnectionString))
        {
            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();
            }
            using (SqlCommand objCmd = objConn.CreateCommand())
            {

                try
                {
                    #region Prepare Command
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "[dbo].[PR_State_SelectAll]";
                    #endregion Prepare Command

                    #region ReadData and set Controls
                    DataTable dt = new DataTable();
                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        dt.Load(objSDR);
                    }
                    return dt;
                    #endregion ReadData and set Controls

                }
                catch (SqlException sqlex)
                {
                    Message = sqlex.Message;
                    return null;
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                    return null;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                    {
                        objConn.Close();
                    }
                }

            }
        }
    }

    #endregion Select All

    #region SelectForDropDownList

    public DataTable SelectForDropDownList()
    {
        using (SqlConnection objConn = new SqlConnection(ConnectionString))
        {
            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();
            }
            using (SqlCommand objCmd = objConn.CreateCommand())
            {

                try
                {
                    #region Prepare Command
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "[dbo].[PR_State_SelectForDropDownList]";
                    #endregion Prepare Command

                    #region ReadData and set Controls
                    DataTable dt = new DataTable();
                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        dt.Load(objSDR);
                    }
                    return dt;
                    #endregion ReadData and set Controls

                }
                catch (SqlException sqlex)
                {
                    Message = sqlex.Message;
                    return null;
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                    return null;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                    {
                        objConn.Close();
                    }
                }

            }
        }
    }
    #endregion SelectForDropDownList



    #region SelectByPK
    public StateENT SelectByPK(SqlInt32 StateID)
    {
        using (SqlConnection objConn = new SqlConnection(ConnectionString))
        {
            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();
            }
            using (SqlCommand objCmd = objConn.CreateCommand())
            {

                try
                {
                    #region Prepare Command
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "[dbo].[PR_State_SelectByPK]";
                    objCmd.Parameters.AddWithValue("@StateID", StateID.ToString().Trim());
                    #endregion Prepare Command

                    #region ReadData and set Controls
                    StateENT entState = new StateENT();
                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        while (objSDR.Read())
                        {
                            if (!objSDR["StateID"].Equals(DBNull.Value))
                            {
                                entState.StateID = Convert.ToInt32(objSDR["StateID"].ToString().Trim());
                            }
                            if (!objSDR["CountryID"].Equals(DBNull.Value))
                            {
                                entState.CountryID = Convert.ToInt32(objSDR["CountryID"].ToString().Trim());
                            }
                            if (!objSDR["StateName"].Equals(DBNull.Value))
                            {
                                entState.StateName = Convert.ToString(objSDR["StateName"].ToString().Trim());
                            }
                            if (!objSDR["Statecode"].Equals(DBNull.Value))
                            {
                                entState.Statecode = Convert.ToString(objSDR["Statecode"].ToString().Trim());
                            }
                            break;
                        }
                    }

                    return entState;
                    #endregion ReadData and set Controls
                }

                catch (SqlException sqlex)
                {
                    Message = sqlex.Message;
                    return null;
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                    return null;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                    {
                        objConn.Close();
                    }
                }
            }
        }
    }

    #endregion SelectByPK

    #endregion Select
}
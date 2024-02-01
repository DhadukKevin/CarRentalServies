using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using CarRentalServies.Areas.Admin.Models;

namespace CarRentalServies.Areas.Admin.DAL
{
    public class AddressBook_DALBase : DALHelper
    {
        #region Method : Country SelectAll
        public DataTable CountrySelecttAll()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Country_SelectAll");
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method : Country Delete
        public bool CountryDelete(int CountryID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Country_Delete");
                sqlDatabase.AddInParameter(dbCommand, "@CountryID", DbType.Int32, CountryID);
                bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                return isSuccess;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Method : Country Insert & Update
        public bool CountrySave(CountryModel modelCountry)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            try
            {
                if (modelCountry.CountryID == null)
                {
                    Admin_DAL adminDAL = new Admin_DAL();
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Country_Insert");
                    sqlDatabase.AddInParameter(dbCommand, "@CountryName", DbType.String, modelCountry.CountryName);
                    sqlDatabase.AddInParameter(dbCommand, "@CountryCode", DbType.String, modelCountry.CountryCode);
                    bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                    return isSuccess;
                }
                else
                {

                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Country_Update");

                    sqlDatabase.AddInParameter(dbCommand, "@CountryID", DbType.Int32, modelCountry.CountryID);
                    sqlDatabase.AddInParameter(dbCommand, "@CountryName", DbType.String, modelCountry.CountryName);
                    sqlDatabase.AddInParameter(dbCommand, "@CountryCode", DbType.String, modelCountry.CountryCode);
                    bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                    return isSuccess;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Method : Country By ID
        public CountryModel CountryByID(int? CountryID)
        {
            CountryModel modelCountry = new CountryModel();
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Country_SelectByID");
                sqlDatabase.AddInParameter(dbCommand, "@CountryID", DbType.Int32, CountryID);
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    modelCountry.CountryName = dataRow["CountryName"].ToString();
                    modelCountry.CountryCode = dataRow["CountryCode"].ToString();
                }
                return modelCountry;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method : State SelectAll
        public DataTable StateSelecttAll()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_State_SelectAll");
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method : State Delete
        public bool StateDelete(int StateID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_state_Delete");
                sqlDatabase.AddInParameter(dbCommand, "@StateID", DbType.Int32, StateID);
                bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                return isSuccess;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Method : State Insert & Update
        public bool StateSave(StateModel modelState)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            try
            {
                if (modelState.StateID == null)
                {
                    Admin_DAL adminDAL = new Admin_DAL();
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_State_Insert");
                    sqlDatabase.AddInParameter(dbCommand, "@StateName", DbType.String, modelState.StateName);
                    sqlDatabase.AddInParameter(dbCommand, "@StateCode", DbType.String, modelState.StateCode);
                    sqlDatabase.AddInParameter(dbCommand, "@CountryID", DbType.Int32, modelState.CountryID);
                    bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                    return isSuccess;
                }
                else
                {

                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_State_Update");

                    sqlDatabase.AddInParameter(dbCommand, "@StateID", DbType.Int32, modelState.StateID);
                    sqlDatabase.AddInParameter(dbCommand, "@StateName", DbType.String, modelState.StateName);
                    sqlDatabase.AddInParameter(dbCommand, "@StateCode", DbType.String, modelState.StateCode);
                    sqlDatabase.AddInParameter(dbCommand, "@CountryID", DbType.Int32, modelState.CountryID);
                    bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                    return isSuccess;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Method : State By ID
        public StateModel StateByID(int? StateID)
        {
            StateModel modelState = new StateModel();
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_State_SelectByID");
                sqlDatabase.AddInParameter(dbCommand, "@StateID", DbType.Int32, StateID);
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    modelState.StateName = dataRow["StateName"].ToString();
                    modelState.StateCode = dataRow["StateCode"].ToString();
                    modelState.CountryID = Convert.ToInt32(dataRow["CountryID"]);
                }
                return modelState;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method : City SelectAll
        public DataTable CitySelecttAll()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_City_SelectAll");
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method : City Delete
        public bool CityDelete(int CityID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_City_Delete");
                sqlDatabase.AddInParameter(dbCommand, "@CityID", DbType.Int32, CityID);
                bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                return isSuccess;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Method : City Insert & Update
        public bool CitySave(CityModel modelCity)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            try
            {
                if (modelCity.CityID == null)
                {
                    Admin_DAL adminDAL = new Admin_DAL();
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_City_Insert");
                    sqlDatabase.AddInParameter(dbCommand, "@CityName", DbType.String, modelCity.CityName);
                    sqlDatabase.AddInParameter(dbCommand, "@CityCode", DbType.String, modelCity.CityCode);
                    sqlDatabase.AddInParameter(dbCommand, "@StateID", DbType.Int32, modelCity.StateID);
                    bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                    return isSuccess;
                }
                else
                {

                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_City_Update");

                    sqlDatabase.AddInParameter(dbCommand, "@CityID", DbType.Int32, modelCity.CityID);
                    sqlDatabase.AddInParameter(dbCommand, "@CityName", DbType.String, modelCity.CityName);
                    sqlDatabase.AddInParameter(dbCommand, "@CityCode", DbType.String, modelCity.CityCode);
                    sqlDatabase.AddInParameter(dbCommand, "@StateID", DbType.Int32, modelCity.StateID);
                    bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                    return isSuccess;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Method : City By ID
        public CityModel CityByID(int? CityID)
        {
            CityModel modelCity = new CityModel();
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_City_SelectByID");
                sqlDatabase.AddInParameter(dbCommand, "@CityID", DbType.Int32, CityID);
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    modelCity.CityName = dataRow["CityName"].ToString();
                    modelCity.CityCode = dataRow["CityCode"].ToString();
                    modelCity.StateID = Convert.ToInt32(dataRow["StateID"]);
                }
                return modelCity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}

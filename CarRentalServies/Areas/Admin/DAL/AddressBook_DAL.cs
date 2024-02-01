using CarRentalServies.Areas.Admin.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace CarRentalServies.Areas.Admin.DAL
{
    public class AddressBook_DAL : AddressBook_DALBase
    {
        #region Country DropDown
        public List<CountryDropDownModel> CountryDropDown()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Country_ComboBox");
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                List<CountryDropDownModel> listOfCategories = new List<CountryDropDownModel>();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    CountryDropDownModel countryDropDownModel = new CountryDropDownModel();
                    countryDropDownModel.CountryID = Convert.ToInt32(dataRow["CountryID"]);
                    countryDropDownModel.CountryName = dataRow["CountryName"].ToString();
                    listOfCategories.Add(countryDropDownModel);
                }
                return listOfCategories;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region City DropDown
        public List<CityDropDownModel> CityDropDown()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_City_ComboBox");
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                List<CityDropDownModel> listOfCategories = new List<CityDropDownModel>();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    CityDropDownModel cityDropDownModel = new CityDropDownModel();
                    cityDropDownModel.CityID = Convert.ToInt32(dataRow["CityID"]);
                    cityDropDownModel.CityName = dataRow["CityName"].ToString();
                    listOfCategories.Add(cityDropDownModel);
                }
                return listOfCategories;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region State DropDown
        public List<StateDropDownModel> StateDropDown()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_State_ComboBox");
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                List<StateDropDownModel> listOfCategories = new List<StateDropDownModel>();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    StateDropDownModel stateDropDownModel = new StateDropDownModel();

                    stateDropDownModel.StateID = Convert.ToInt32(dataRow["StateID"]);
                    stateDropDownModel.StateName = dataRow["StateName"].ToString();
                    listOfCategories.Add(stateDropDownModel);
                }
                return listOfCategories;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method : Country SelectAll
        public DataTable CountryFilter(CountryFilterModel filterModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Country_filter");
                sqlDatabase.AddInParameter(dbCommand, "@CountryName", DbType.String, filterModel.CountryName);
                sqlDatabase.AddInParameter(dbCommand, "@CountryCode", DbType.String, filterModel.CountryCode);
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

        #region Method : State SelectAll
        public DataTable StateFilter(StateFilterModel filterModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_State_filter");
                sqlDatabase.AddInParameter(dbCommand, "@StateName", DbType.String, filterModel.StateName);
                sqlDatabase.AddInParameter(dbCommand, "@CountryID", DbType.Int32, filterModel.CountryID);
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

        #region Method : City Filter
        public DataTable CityFilter(CityFilterModel filterModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_City_filter");
                sqlDatabase.AddInParameter(dbCommand, "@CityName", DbType.String, filterModel.CityName);
                sqlDatabase.AddInParameter(dbCommand, "@StateID", DbType.Int32, filterModel.StateID);
                sqlDatabase.AddInParameter(dbCommand, "@CountryID", DbType.Int32, filterModel.CountryID);
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
    }
}

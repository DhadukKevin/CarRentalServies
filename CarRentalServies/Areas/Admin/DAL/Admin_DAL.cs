
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using CarRentalServies.Areas.Admin.Models;

namespace CarRentalServies.Areas.Admin.DAL
{
    public class Admin_DAL : Admin_DALBase
    {
        #region CarTypeDropDown
        public List<CarTypeDropDownModel> CarTypeDropDown()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_CarType_ComboBox");
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                List<CarTypeDropDownModel> listOfCategories = new List<CarTypeDropDownModel>();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    CarTypeDropDownModel carTypeDropDownModel = new CarTypeDropDownModel();
                    carTypeDropDownModel.CarTypeID = Convert.ToInt32(dataRow["CarTypeID"]);
                    carTypeDropDownModel.CarTypeName = dataRow["CarTypeName"].ToString();
                    listOfCategories.Add(carTypeDropDownModel);
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

        #region Fuel DropDown
        public List<FuelTypeDropDownModel> FuelDropDown()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_FuelType_ComboBox");
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                List<FuelTypeDropDownModel> listOfCategories = new List<FuelTypeDropDownModel>();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    FuelTypeDropDownModel fuelDropDownModel = new FuelTypeDropDownModel();
                    fuelDropDownModel.FuelID = Convert.ToInt32(dataRow["FuelID"]);
                    fuelDropDownModel.FuelTypeName = dataRow["FuelTypeName"].ToString();
                    listOfCategories.Add(fuelDropDownModel);
                }
                return listOfCategories;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Transmissin DropDown
        public List<TransmissionDropDownModel> TransmissionDropDown()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Transmission_ComboBox");
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                List<TransmissionDropDownModel> listOfCategories = new List<TransmissionDropDownModel>();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    TransmissionDropDownModel transmissionDropDownModel = new TransmissionDropDownModel();
                    transmissionDropDownModel.TransmissionID = Convert.ToInt32(dataRow["TransmissionID"]);
                    transmissionDropDownModel.TransmissionName = dataRow["TransmissionName"].ToString();
                    listOfCategories.Add(transmissionDropDownModel);
                }
                return listOfCategories;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method : User Filter
        public DataTable UserFilter(UserFilterModel filterModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_User_Filter");
                sqlDatabase.AddInParameter(dbCommand, "@Name", DbType.String, filterModel.Name);
                sqlDatabase.AddInParameter(dbCommand, "@CityID", DbType.Int32, filterModel.CityID);
                sqlDatabase.AddInParameter(dbCommand, "@StateID", DbType.Int32, filterModel.StateID);
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

        #region Method : Car Filter
        public DataTable CarFilter(CarFilterModel filterModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_Car_Filter");
                sqlDatabase.AddInParameter(dbCommand, "@CarName", DbType.String, filterModel.CarName);
                sqlDatabase.AddInParameter(dbCommand, "@CityID", DbType.Int32, filterModel.CityID);
                sqlDatabase.AddInParameter(dbCommand, "@StateID", DbType.Int32, filterModel.StateID);
                sqlDatabase.AddInParameter(dbCommand, "@TransmissionID", DbType.Int32, filterModel.TransmissionID);
                sqlDatabase.AddInParameter(dbCommand, "@FuelID", DbType.Int32, filterModel.FuelID);
                sqlDatabase.AddInParameter(dbCommand, "@CarTypeID", DbType.Int32, filterModel.CarTypeID);
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

        #region Car Count
        public int CarCount()
        {
            int CarCount=0;
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Car_Count");
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
            {
                dataTable.Load(dataReader);
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                CarCount = Convert.ToInt32(dataRow["CarCount"]);
            }
            return CarCount;
        }
        #endregion

        #region City Count
        public int CityCount()
        {
            int CityCount = 0;
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_City_Count");
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
            {
                dataTable.Load(dataReader);
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                CityCount = Convert.ToInt32(dataRow["CityCount"]);
            }
            return CityCount;
        }
        #endregion

        #region User Count
        public int UserCount()
        {
            int UserCount = 0;
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_User_Count");
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
            {
                dataTable.Load(dataReader);
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                UserCount = Convert.ToInt32(dataRow["UserCount"]);
            }
            return UserCount;
        }
        #endregion

        #region Count Table
        public DataTable CountTable()
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_User_CountByCity");
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        #endregion
    }
}

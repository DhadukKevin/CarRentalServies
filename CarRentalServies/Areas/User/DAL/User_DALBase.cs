using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using CarRentalServies.Areas.User.Models;
using CarRentalServies.BAL;

namespace CarRentalServies.Areas.User.DAL
{
    public class User_DALBase : DALHelper
    {
        #region Car By City
        public DataTable CarFilterByCity(int? cityID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                if (cityID == null)
                {
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_Car_SelectAll");
                    DataTable dataTable = new DataTable();
                    using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                    {
                        dataTable.Load(dataReader);
                    }
                    return dataTable;
                }
                else
                {
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_CAR_FilterByCity");
                    sqlDatabase.AddInParameter(dbCommand, "@CityID", DbType.Int32, cityID);
                    DataTable dataTable = new DataTable();
                    using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                    {
                        dataTable.Load(dataReader);
                    }
                    return dataTable;
                }
                
               
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Car By ID
        public CarModel CarByID(int? CarID)
        {
            CarModel modelCar = new CarModel();
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_car_SelectByPk");
                sqlDatabase.AddInParameter(dbCommand, "@CarID", DbType.Int32, CarID);
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    modelCar.CarID = Convert.ToInt32(dataRow["CarID"]);
                    modelCar.CarName = dataRow["CarName"].ToString();
                    modelCar.CarPhoto = dataRow["CarPhoto"].ToString();
                    modelCar.TransmissionID = Convert.ToInt32(dataRow["TransmissionID"]);
                    modelCar.TransmissionName = dataRow["TransmissionName"].ToString();
                    modelCar.FuelID = Convert.ToInt32(dataRow["FuelID"]);
                    modelCar.FuelName = dataRow["FuelTypeName"].ToString();
                    modelCar.CarTypeID = Convert.ToInt32(dataRow["CarTypeID"]);
                    modelCar.CarTypeName = dataRow["CarTypeName"].ToString();
                    modelCar.SeatNumber = Convert.ToInt32(dataRow["SeatNumber"]);
                    modelCar.CarDetail = dataRow["CarDetail"].ToString();
                    modelCar.Kms = Convert.ToDecimal(dataRow["Kms"]);
                    modelCar.CityID = Convert.ToInt32(dataRow["CityID"]);
                    modelCar.CityName = dataRow["CityName"].ToString();
                    modelCar.Location = dataRow["Location"].ToString();
                    modelCar.Price = Convert.ToDecimal(dataRow["Price"]);
                    //modelCar.FromDate = Convert.ToDateTime(dataRow["FromDate"]);
                    //if (Convert.ToDateTime(dataRow["FromDate"]).Equals(null))
                    //{
                    //    modelCar.FromDate = null;
                    //    modelCar.ToDate = null;
                    //}
                    if(dataRow["FromDate"] is DBNull)
                    {
                        modelCar.FromDate = null;
                        modelCar.ToDate = null;
                    }
                    else
                    {
                        modelCar.FromDate = Convert.ToDateTime(dataRow["FromDate"]);
                        modelCar.ToDate = Convert.ToDateTime(dataRow["ToDate"]);
                    }
                    
                }
                return modelCar;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Car By CityID, FromDate, ToDate
        public DataTable CarByCityIDFromDateToDate(int CityID,DateTime FromDate,DateTime ToDate)
        {
            CarModel modelCar = new CarModel();
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_CAR_FilterByCityAndDateTime");
                sqlDatabase.AddInParameter(dbCommand, "@CityID", DbType.Int32, CityID);
                sqlDatabase.AddInParameter(dbCommand, "@FromDate", DbType.DateTime, FromDate);
                sqlDatabase.AddInParameter(dbCommand, "@ToDate", DbType.DateTime, ToDate);
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

        #region Booking
        public bool BookingSave(int CarID,int UserID,string FromDate, string ToDate,string TotalFare)
        {
            DateTime From = Convert.ToDateTime(FromDate);
            DateTime To = Convert.ToDateTime(ToDate);
            Decimal price = Convert.ToDecimal(TotalFare);
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Booking_Insert");
            sqlDatabase.AddInParameter(dbCommand, "@CarID", DbType.Int32, CarID);
            sqlDatabase.AddInParameter(dbCommand, "@UserID", DbType.Int32, UserID);
            sqlDatabase.AddInParameter(dbCommand, "@FromDate", DbType.DateTime, From);
            sqlDatabase.AddInParameter(dbCommand, "@ToDate", DbType.DateTime, To);
            sqlDatabase.AddInParameter(dbCommand, "@TotalFare", DbType.Decimal, price);
            bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
            return isSuccess;
        }
        #endregion

        #region BookingList
        public DataTable BookinghList(int UserID)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Booking_SelectByUserID");
            sqlDatabase.AddInParameter(dbCommand, "@UserID", DbType.Int32, UserID);
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        #endregion

        #region BookingList
        public DataTable BookinghListSelectall()
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Booking_SelectAll");
            DataTable dataTable = new DataTable();
            using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
            {
                dataTable.Load(dataReader);
            }
            return dataTable;
        }
        #endregion

        #region Update From and To Date in Car
        public bool UpdateFromAndToDateInCar(int CarID,string? FromDate,string? ToDate)
        {
            DateTime? From = Convert.ToDateTime(FromDate);
            DateTime? To = Convert.ToDateTime(ToDate);
            DateTime date2 = new DateTime(0001, 01, 01, 00, 00, 00);
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_Car_UpdateFromAndToDate");

            if (From == date2 & To == date2)
            {
                sqlDatabase.AddInParameter(dbCommand, "@CarID", DbType.Int32, CarID);
                sqlDatabase.AddInParameter(dbCommand, "@FromDate", DbType.Int32, null);
                sqlDatabase.AddInParameter(dbCommand, "@ToDate", DbType.Int32, null);
                
            }
            else
            {
                sqlDatabase.AddInParameter(dbCommand, "@CarID", DbType.Int32, CarID);
                sqlDatabase.AddInParameter(dbCommand, "@FromDate", DbType.DateTime, From);
                sqlDatabase.AddInParameter(dbCommand, "@ToDate", DbType.DateTime, To);
            }

            
            bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
            return isSuccess;
        }
        #endregion
 
        #region User Filter
        public DataTable User_Filter(CarFilterModelUser modelCarUser, int CityID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_Car_Filter_User");
                sqlDatabase.AddInParameter(dbCommand, "@CarName", DbType.String, modelCarUser.CarName);
                sqlDatabase.AddInParameter(dbCommand, "@TransmissionID", DbType.Int32, modelCarUser.TransmissionID);
                sqlDatabase.AddInParameter(dbCommand, "@FuelID", DbType.Int32, modelCarUser.FuelID);
                sqlDatabase.AddInParameter(dbCommand, "@CarTypeID", DbType.Int32, modelCarUser.CarTypeID);
                sqlDatabase.AddInParameter(dbCommand, "@SeatNumber", DbType.Int32, modelCarUser.SeatNumber);
                sqlDatabase.AddInParameter(dbCommand, "@CityID", DbType.Int32, CityID);
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

        public bool Rating(RatingModel modelRating)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Rating_Insert");
                sqlDatabase.AddInParameter(dbCommand, "@Rating", DbType.String,modelRating.Rating);
                sqlDatabase.AddInParameter(dbCommand, "@CarID", DbType.Int32, modelRating.CarID);
                sqlDatabase.AddInParameter(dbCommand, "@UserID", DbType.Int32, Convert.ToInt32(CV.UserID()));
                sqlDatabase.AddInParameter(dbCommand, "@Review", DbType.String, modelRating.Review);
                bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                return isSuccess;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #region Method : Feature By CarID
        public DataTable FeatureByCarID(int CarID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_FeatureName");
                sqlDatabase.AddInParameter(dbCommand, "@CarID", DbType.Int32, CarID);
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

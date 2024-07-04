using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using CarRentalServies.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace CarRentalServies.Areas.Admin.DAL
{
    public class Admin_DALBase : DALHelper
    {
        #region Method : Car SelectAll
        public DataTable CarSelectAll()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_Car_SelectAll");
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

        #region Method : Select Car Whose From Date And To Date Is Not Null
        public DataTable CarSelectByFromAndToDate()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_Car_Select_By_FromDate_ToDate");
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

        #region Method : Car Delete
        public bool CarDelete(int CarID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_Car_Delete");
                sqlDatabase.AddInParameter(dbCommand, "@CarID", DbType.Int32, CarID);
                bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                return isSuccess;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Method : Car Insert & Update
        public bool CarSave(CarModel modelCar)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            try
            {
                if (modelCar.CarID == null)
                {
                    Admin_DAL adminDAL = new Admin_DAL();

                    if (modelCar.CarImage != null)
                    {
                        string FilePath = "wwwroot\\images";
                        string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        string fileNameWithPath = Path.Combine(path, modelCar.CarImage.FileName);

                        modelCar.CarPhoto = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + modelCar.CarImage.FileName;

                        using (FileStream fileStream = new FileStream(fileNameWithPath, FileMode.Create))
                        {
                            modelCar.CarImage.CopyTo(fileStream);
                        }
                    }
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_Car_Insert");
                    sqlDatabase.AddInParameter(dbCommand, "@CarName", DbType.String, modelCar.CarName);
                    sqlDatabase.AddInParameter(dbCommand, "@CarPhoto", DbType.String, modelCar.CarPhoto);
                    sqlDatabase.AddInParameter(dbCommand, "@TransmissionID", DbType.Int32, modelCar.TransmissionID);
                    sqlDatabase.AddInParameter(dbCommand, "@FuelID", DbType.Int32, modelCar.FuelID);
                    sqlDatabase.AddInParameter(dbCommand, "@CarTypeID", DbType.Int32, modelCar.CarTypeID);
                    sqlDatabase.AddInParameter(dbCommand, "@CarDetail", DbType.String, modelCar.CarDetail);
                    sqlDatabase.AddInParameter(dbCommand, "@Kms", DbType.Decimal, modelCar.Kms);
                    sqlDatabase.AddInParameter(dbCommand, "@CityID", DbType.Int32, modelCar.CityID);
                    sqlDatabase.AddInParameter(dbCommand, "@Location", DbType.String, modelCar.Location);
                    sqlDatabase.AddInParameter(dbCommand, "@Price", DbType.Decimal, modelCar.Price);
                    Console.WriteLine("SuccessDALAdd");
                    bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                    return isSuccess;
                }
                else
                {
                    if (modelCar.CarImage != null)
                    {
                        string FilePath = "wwwroot\\images";
                        string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        string fileNameWithPath = Path.Combine(path, modelCar.CarImage.FileName);

                        modelCar.CarPhoto = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + modelCar.CarImage.FileName;

                        using (FileStream fileStream = new FileStream(fileNameWithPath, FileMode.Create))
                        {
                            modelCar.CarImage.CopyTo(fileStream);
                        }
                    }
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_Car_UpdateByPk");

                    sqlDatabase.AddInParameter(dbCommand, "@CarID", DbType.Int32, modelCar.CarID);
                    sqlDatabase.AddInParameter(dbCommand, "@CarName", DbType.String, modelCar.CarName);
                    sqlDatabase.AddInParameter(dbCommand, "@CarPhoto", DbType.String, modelCar.CarPhoto);
                    sqlDatabase.AddInParameter(dbCommand, "@TransmissionID", DbType.Int32, modelCar.TransmissionID);
                    sqlDatabase.AddInParameter(dbCommand, "@FuelID", DbType.Int32, modelCar.FuelID);
                    sqlDatabase.AddInParameter(dbCommand, "@CarTypeID", DbType.Int32, modelCar.CarTypeID);
                    sqlDatabase.AddInParameter(dbCommand, "@CarDetail", DbType.String, modelCar.CarDetail);
                    sqlDatabase.AddInParameter(dbCommand, "@Kms", DbType.Decimal, modelCar.Kms);
                    sqlDatabase.AddInParameter(dbCommand, "@CityID", DbType.Int32, modelCar.CityID);
                    sqlDatabase.AddInParameter(dbCommand, "@Location", DbType.String, modelCar.Location);
                    sqlDatabase.AddInParameter(dbCommand, "@Price", DbType.Decimal, modelCar.Price);
                    Console.WriteLine("SuccessDALUpdate");
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

        #region Method : Car By ID
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
                    Console.WriteLine(dataRow["CarName"].ToString());
                    modelCar.CarName = dataRow["CarName"].ToString();
                    modelCar.CarPhoto = dataRow["CarPhoto"].ToString();
                    modelCar.TransmissionID = Convert.ToInt32(dataRow["TransmissionID"]);
                    modelCar.FuelID = Convert.ToInt32(dataRow["FuelID"]);
                    modelCar.CarTypeID = Convert.ToInt32(dataRow["CarTypeID"]);
                    modelCar.CarDetail = dataRow["CarDetail"].ToString();
                    modelCar.Kms = Convert.ToDecimal(dataRow["Kms"]);
                    modelCar.CityID = Convert.ToInt32(dataRow["CityID"]);
                    modelCar.Location = dataRow["Location"].ToString();
                    modelCar.Price = Convert.ToDecimal(dataRow["Price"]);
                }
                return modelCar;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method : User SelectAll
        public DataTable UserSelectAll()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_User_SelectAll");
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

        #region Method : User Delete
        public bool UserDelete(int UserID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_User_Delete");
                sqlDatabase.AddInParameter(dbCommand, "@UserID", DbType.Int32, UserID);
                bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                return isSuccess;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Method : Car Insert & Update
        public bool UserSave(UserModel modelUser)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            try
            {
                if (modelUser.UserID == null)
                {
                    Admin_DAL adminDAL = new Admin_DAL();
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_User_Register");
                    sqlDatabase.AddInParameter(dbCommand, "@Name", DbType.String, modelUser.Name);
                    sqlDatabase.AddInParameter(dbCommand, "@Email", DbType.String, modelUser.Email);
                    sqlDatabase.AddInParameter(dbCommand, "@CityID", DbType.Int32, modelUser.CityID);
                    sqlDatabase.AddInParameter(dbCommand, "@Password", DbType.String, modelUser.Password);
                    Console.WriteLine("SuccessDALAdd");
                    bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                    return isSuccess;
                }
                else
                {
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_User_UpdateByPk");
                    sqlDatabase.AddInParameter(dbCommand, "@UserID", DbType.Int32, modelUser.UserID);
                    sqlDatabase.AddInParameter(dbCommand, "@Name", DbType.String, modelUser.Name);
                    sqlDatabase.AddInParameter(dbCommand, "@Email", DbType.String, modelUser.Email);
                    sqlDatabase.AddInParameter(dbCommand, "@Password", DbType.String, modelUser.Password);
                    sqlDatabase.AddInParameter(dbCommand, "@CityID", DbType.Int32, modelUser.CityID);
                    //sqlDatabase.AddInParameter(dbCommand, "@ProfilePhoto", DbType.String, modelUser.ProfilePhoto);
                    sqlDatabase.AddInParameter(dbCommand, "@MobileNo", DbType.String, modelUser.MobileNo);
                    Console.WriteLine("SuccessDALUpdate");
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

        #region Method : Car By ID
        public UserModel UserByID(int UserID)
        {
            UserModel modelUser = new UserModel();
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_User_SelectByID");
                sqlDatabase.AddInParameter(dbCommand, "@UserID", DbType.Int32, UserID);
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    modelUser.UserID = Convert.ToInt32(dataRow["UserID"]);
                    modelUser.Name = dataRow["Name"].ToString();
                    modelUser.Password = dataRow["Password"].ToString();
                    modelUser.Email = dataRow["Email"].ToString();
                    modelUser.MobileNo = dataRow["MobileNo"].ToString();
                    modelUser.CityID = Convert.ToInt32(dataRow["CityID"]);
                    modelUser.ProfilePhoto = dataRow["ProfilePhoto"].ToString();
                }
                return modelUser;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Update From and To Date in Car
        public bool UpdateFromAndToDateInCar(int CarID)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_Car_UpdateFromAndToDate");

            sqlDatabase.AddInParameter(dbCommand, "@CarID", DbType.Int32, CarID);
            sqlDatabase.AddInParameter(dbCommand, "@FromDate", DbType.Int32, null);
            sqlDatabase.AddInParameter(dbCommand, "@ToDate", DbType.Int32, null);

            bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
            return isSuccess;
        }
        #endregion
    }
}

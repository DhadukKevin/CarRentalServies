﻿using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using CarRentalServies.Areas.Admin.Models;

namespace CarRentalServies.Areas.Admin.DAL
{
    public class Car_DALBase : DALHelper
    {
        #region Method : Car Type SelectAll
        public DataTable CarTypeSelecttAll()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_CarType_SelectAll");
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

        #region Method : Car Type Delete
        public bool CarTypeDelete(int CarTypeID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_CarType_Delete");
                sqlDatabase.AddInParameter(dbCommand, "@CarTypeID", DbType.Int32, CarTypeID);
                bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                return isSuccess;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Method : Car Type Insert & Update
        public bool CarTypeSave(CarTypeModel modelCarType)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            try
            {
                if (modelCarType.CarTypeID == null)
                {
                    Admin_DAL adminDAL = new Admin_DAL();
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_CarType_Insert");
                    sqlDatabase.AddInParameter(dbCommand, "@CarTypeName", DbType.String, modelCarType.CarTypeName);
                    sqlDatabase.AddInParameter(dbCommand, "@SeatNumber", DbType.Int32, modelCarType.SeatNumber);
                    bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                    return isSuccess;
                }
                else
                {

                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_CarType_Update");

                    sqlDatabase.AddInParameter(dbCommand, "@CarTypeID", DbType.Int32, modelCarType.CarTypeID);
                    sqlDatabase.AddInParameter(dbCommand, "@CarTypeName", DbType.String, modelCarType.CarTypeName);
                    sqlDatabase.AddInParameter(dbCommand, "@SeatNumber", DbType.Int32, modelCarType.SeatNumber);
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

        #region Method : Car Type By ID
        public CarTypeModel CarTypeByID(int? CarTypeID)
        {
            CarTypeModel modelCarType = new CarTypeModel();
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_CarType_SelectByID");
                sqlDatabase.AddInParameter(dbCommand, "@CarTypeID", DbType.Int32, CarTypeID);
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    modelCarType.CarTypeName = dataRow["CarTypeName"].ToString();
                    modelCarType.SeatNumber = Convert.ToInt32(dataRow["SeatNumber"]);
                }
                return modelCarType;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method : Fuel Type SelectAll
        public DataTable FuelTypeSelecttAll()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_FuelType_SelectAll");
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

        #region Method : Fuel Type Delete
        public bool FuelTypeDelete(int FuelID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Fuel_Delete");
                sqlDatabase.AddInParameter(dbCommand, "@FuelID", DbType.Int32, FuelID);
                bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                return isSuccess;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Method : Fuel Type Insert & Update
        public bool FuelTypeSave(FuelTypeModel modelFuelType)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            try
            {
                if (modelFuelType.FuelID == null)
                {
                    Admin_DAL adminDAL = new Admin_DAL();
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Fuel_Insert");
                    sqlDatabase.AddInParameter(dbCommand, "@FuelTypeName", DbType.String, modelFuelType.FuelTypeName);
                    bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                    return isSuccess;
                }
                else
                {

                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Fuel_Update");

                    sqlDatabase.AddInParameter(dbCommand, "@FuelID", DbType.Int32, modelFuelType.FuelID);
                    sqlDatabase.AddInParameter(dbCommand, "@FuelTypeName", DbType.String, modelFuelType.FuelTypeName);
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

        #region Method : Fuel Type By ID
        public FuelTypeModel FuelTypeByID(int? FuelID)
        {
            FuelTypeModel modelFuelType = new FuelTypeModel();
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_FuelType_SelectByID");
                sqlDatabase.AddInParameter(dbCommand, "@FuelID", DbType.Int32, FuelID);
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    modelFuelType.FuelTypeName = dataRow["FuelTypeName"].ToString();
                }
                return modelFuelType;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method : Transmission SelectAll
        public DataTable TransmissionSelecttAll()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Transmission_SelectAll");
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

        #region Method : Transmission Delete
        public bool TransmissionDelete(int TransmissionID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Transmission_Delete");
                sqlDatabase.AddInParameter(dbCommand, "@TransmissionID", DbType.Int32, TransmissionID);
                bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                return isSuccess;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Method : Transmission Insert & Update
        public bool TransmissionSave(TransmissionModel modelTransmissionType)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            try
            {
                if (modelTransmissionType.TransmissionID == null)
                {
                    Admin_DAL adminDAL = new Admin_DAL();
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Transmission_Insert");
                    sqlDatabase.AddInParameter(dbCommand, "@TransmissionName", DbType.String, modelTransmissionType.TransmissionName);
                    bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                    return isSuccess;
                }
                else
                {

                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Transmission_Update");

                    sqlDatabase.AddInParameter(dbCommand, "@TransmissionID", DbType.Int32, modelTransmissionType.TransmissionID);
                    sqlDatabase.AddInParameter(dbCommand, "@TransmissionName", DbType.String, modelTransmissionType.TransmissionName);
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

        #region Method : Transmission By ID
        public TransmissionModel TransmissionByID(int? TransmissionID)
        {
            TransmissionModel modelTransmission = new TransmissionModel();
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Transmission_SelectByID");
                sqlDatabase.AddInParameter(dbCommand, "@TransmissionID", DbType.Int32, TransmissionID);
                DataTable dataTable = new DataTable();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataTable.Load(dataReader);
                }
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    modelTransmission.TransmissionName = dataRow["TransmissionName"].ToString();
                }
                return modelTransmission;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        public List<FeaturePostModel> GetFeaturePosts(FeatureModel modelFeature,int CarID)
        {
            List<FeaturePostModel> items = new List<FeaturePostModel>
            {
                new FeaturePostModel { CarID = CarID, FeatureID = modelFeature.Airconditions },
                new FeaturePostModel { CarID = CarID, FeatureID = modelFeature.Child_Seat },
                new FeaturePostModel { CarID = CarID, FeatureID = modelFeature.GPS },
                new FeaturePostModel { CarID = CarID, FeatureID = modelFeature.Luggage },
                new FeaturePostModel { CarID = CarID, FeatureID = modelFeature.Music },
                new FeaturePostModel { CarID = CarID, FeatureID = modelFeature.Seat_Belt },
                new FeaturePostModel { CarID = CarID, FeatureID = modelFeature.Sleeping_Bed },
                new FeaturePostModel { CarID = CarID, FeatureID = modelFeature.Water },
                new FeaturePostModel { CarID = CarID, FeatureID = modelFeature.Bluetooth },
                new FeaturePostModel { CarID = CarID, FeatureID = modelFeature.Onboard_computer },
                new FeaturePostModel { CarID = CarID, FeatureID = modelFeature.Audio_input },
                new FeaturePostModel { CarID = CarID, FeatureID = modelFeature.Long_Term_Trips },
                new FeaturePostModel { CarID = CarID, FeatureID = modelFeature.Car_Kit },
                new FeaturePostModel { CarID = CarID, FeatureID = modelFeature.Remote_central_locking },
                new FeaturePostModel { CarID = CarID, FeatureID = modelFeature.Climate_control }
            };

            return items;
        }

        public DataTable FeatureSelectByCarID(int CarID)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Feature_SelectAll");
            sqlDatabase.AddInParameter(dbCommand, "@CarID", DbType.Int32, CarID);
            DataTable dt = new DataTable();
            using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
            {
                dt.Load(dataReader);
            }
            return dt;
        }

        public bool Feature_Insert(int CarID, int? FeatureID)
        
        {
            DataTable dt = FeatureSelectByCarID(CarID);

            if(dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (Convert.ToInt32(dr["CarID"]) == CarID && Convert.ToInt32(dr["FeatureID"]) == FeatureID)
                    {
                        return true;
                    }
                    else
                    {
                        if (FeatureID == null)
                        {
                            return true;
                        }
                        else
                        {
                            SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Feature_Insert");
                            sqlDatabase.AddInParameter(dbCommand, "@CarID", DbType.Int32, CarID);
                            sqlDatabase.AddInParameter(dbCommand, "@FeatureID", DbType.Int32, FeatureID);
                            bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                            return isSuccess;
                        }
                    }
                }
                return false;
            }
            else
            {
                if (FeatureID == null)
                {
                    return true;
                }
                else
                {
                    SqlDatabase sqlDatabase = new SqlDatabase(ConnectionString);
                    DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Feature_Insert");
                    sqlDatabase.AddInParameter(dbCommand, "@CarID", DbType.Int32, CarID);
                    sqlDatabase.AddInParameter(dbCommand, "@FeatureID", DbType.Int32, FeatureID);
                    bool isSuccess = Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                    return isSuccess;
                }
            }
            
        }
    }
}
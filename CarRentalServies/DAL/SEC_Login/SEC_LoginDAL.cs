using CarRentalServies.Areas.Admin.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace CarRentalServies.DAL.SEC_Login
{
    public class SEC_LoginDAL : SEC_LoginDALBase
    {
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
    }
}

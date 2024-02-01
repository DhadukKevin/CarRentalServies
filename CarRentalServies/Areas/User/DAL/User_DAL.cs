using CarRentalServies.Areas.User.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

namespace CarRentalServies.Areas.User.DAL
{
    public class User_DAL : User_DALBase
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

        [HttpPost]
        public bool SendEmail(string receiver)
        {
            try
            {
                
                    var senderEmail = new MailAddress("kevindhaduk444@gmail.com", "Car Rental");
                    var receiverEmail = new MailAddress(receiver, "Receiver");
                    var password = "@Kevin444Dhaduk#";
                    var subject = "Your Car Is Booked";
                    var body = "You Booked Car from car rental servies thank you!!";
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                    return true;
                
            }
            catch (Exception)
            {
                //ViewBag.Error = "Some Error";
            }
            return false;
        }
    }
}

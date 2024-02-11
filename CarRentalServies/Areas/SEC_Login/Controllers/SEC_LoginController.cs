using CarRentalServies.Areas.SEC_Login.Models;
using CarRentalServies.DAL.SEC_Login;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using CarRentalServies.BAL;

namespace CarRentalServies.Areas.SEC_Login.Controllers
{
    [Area("SEC_Login")]
    [Route("SEC_Login/[controller]/[action]")]

    public class SEC_LoginController : Controller
    {
        SEC_LoginDAL loginDal = new SEC_LoginDAL();
        #region Configuration
        private readonly IConfiguration Configuration;

        public SEC_LoginController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        #endregion

        public IActionResult SEC_LoginPage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(SEC_LoginModel modelSEC_User)
        {
            string error = null;
            Console.WriteLine("Hello ", modelSEC_User.Name);
            if (modelSEC_User.Name == null)
            {
                error += "User Name is required";
            }
            if (modelSEC_User.Password == null)
            {
                error += "<br/>Password is required";
            }

            if (error != null)
            {
                TempData["Error"] = error;
                return RedirectToAction("SEC_UserLogin");
            }
            else
            {
                SEC_LoginDAL sEC_UserDAL = new SEC_LoginDAL();
                DataTable dt = sEC_UserDAL.dbo_PR_SEC_Login_SelectByUserNamePassword(modelSEC_User.Name, modelSEC_User.Password);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {

                        HttpContext.Session.SetString("UserID", dr["UserID"].ToString());
                        HttpContext.Session.SetString("Name", dr["Name"].ToString());
                        HttpContext.Session.SetString("Password", dr["Password"].ToString());
                        HttpContext.Session.SetString("Email", dr["Email"].ToString());
                        HttpContext.Session.SetString("ProfilePhoto", dr["ProfilePhoto"].ToString());
                        HttpContext.Session.SetString("CityName", dr["CityName"].ToString());
                        HttpContext.Session.SetString("IsAdmin", dr["IsAdmin"].ToString());
                        HttpContext.Session.SetString("MobileNo", dr["MobileNo"].ToString());
                        break;
                    }
                }
                else
                {
                    TempData["Error"] = "User Name or Password is invalid!";
                    return RedirectToAction("Index", "Home");
                }
                if (HttpContext.Session.GetString("Name") != null && HttpContext.Session.GetString("Password") != null)
                {
                    if (HttpContext.Session.GetString("IsAdmin") == "True")
                    {
                        return RedirectToAction("Index", "Admin", new { area = "Admin" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult SEC_Registration()
        {
            ViewBag.CityList = loginDal.CityDropDown();
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Save(SEC_LoginModel loginSEC_Login)
        {
            string connectionStr = this.Configuration.GetConnectionString("myConnectionString");
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            SqlCommand objCmd = connection.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_MST_User_Register";
            
            objCmd.Parameters.AddWithValue("@Password", loginSEC_Login.Password);
            objCmd.Parameters.AddWithValue("@Name", loginSEC_Login.Name);

            //objCmd.Parameters.AddWithValue("@MobileNo ", loginSEC_Login.ProfilePhoto);
            //objCmd.Parameters.AddWithValue("@MobileNo ", loginSEC_Login.MobileNo);
            objCmd.Parameters.AddWithValue("@Email", loginSEC_Login.Email);
            objCmd.Parameters.AddWithValue("@CityID", loginSEC_Login.CityID);
            objCmd.ExecuteNonQuery();
            connection.Close();

            return RedirectToAction("Index", "Home");
        }
    }
}

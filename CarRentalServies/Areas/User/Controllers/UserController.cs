using CarRentalServies.Areas.Admin.DAL;
using CarRentalServies.Areas.User.DAL;
using CarRentalServies.Areas.User.Models;
using CarRentalServies.BAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Net.Mail;
using System.Net;

namespace CarRentalServies.Areas.User.Controllers
{

    [Area("User")]
    [Route("User/[controller]/[action]")]
    public class UserController : Controller
    {
        User_DAL userDAL = new User_DAL();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Home()
        {
            ViewBag.CityList = userDAL.CityDropDown();
            return View();
        }

        #region Car List
        public IActionResult CarList(int? cityID,string FromDate,string ToDate)
        {
            TempData["FromDate"] = FromDate;
            TempData["ToDate"] = ToDate;
            TempData["CityID"] = cityID;
            DataTable dataTable = userDAL.CarFilterByCity(cityID);
            TempData["CityID"] = cityID;
           
            return View(dataTable);
        }
        #endregion

        #region Car Detail Page
        public IActionResult CarDetailPage(int CarID, string FromDate, string ToDate)
        {
            TempData["FromDate"] = FromDate;
            TempData["ToDate"] = ToDate;
            CarModel modelCar = new CarModel();
            DataTable dt = new DataTable();
            var viewModel = new MyViewModel
            {
                modelCar = userDAL.CarByID(CarID),
                dt = userDAL.FeatureByCarID(CarID)
            };

            return View("CarDetailPage", viewModel);
        }
        #endregion

        #region Car By CityID From and To Date
        public IActionResult CarByCityIDFromDateToDate(int CityID, string FromDate, string ToDate)
        {
            TempData["FromDate"] = FromDate;
            TempData["ToDate"] = ToDate;
            TempData["CityID"] = CityID;
            DataTable dataTable = userDAL.CarByCityIDFromDateToDate(CityID, Convert.ToDateTime(FromDate), Convert.ToDateTime(ToDate));
            return View("CarList", dataTable);
        }
        #endregion

        #region Booking

        [CheckAccess]
        public IActionResult BookinSave(int CarID, int UserID, string FromDate, string ToDate,string TotalFare)
        {
            if (userDAL.BookingSave(CarID, UserID, FromDate, ToDate, TotalFare))
            {
                if (userDAL.UpdateFromAndToDateInCar(CarID, FromDate, ToDate))
                {
                    //userDAL.SendEmail(Email);

                    //Create Message
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("kevindhaduk444@gmail.com");
                    mailMessage.To.Add("kevindhaduk222@gmail.com");
                    mailMessage.Subject = "Test Email";
                    mailMessage.Body = "This is a test email";

                    // Create a SmtpClient to send the email
                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.Port = 587; // Update the port if necessary
                    smtpClient.Credentials = new NetworkCredential("kevindhaduk444@gmail.com", "@Kevin444Dhaduk#");
                    smtpClient.EnableSsl = true; // Enable SSL if required

                    // Send the email
                    smtpClient.Send(mailMessage);
                    return RedirectToAction("BookingList");
                }

            }
            return RedirectToAction("BookingList");
        }
        #endregion

        #region Booking List By UserID
        public IActionResult BookingList()
        {
            int UserID = Convert.ToInt32(CV.UserID());
            DataTable dataTable = userDAL.BookinghList(UserID);
            return View("BookingList", dataTable);
        }
        #endregion


        #region Update From and To date in car
        public IActionResult UpdateCarFromAndToDate(int CarID, string? FromDate, string? ToDate)
        {
            if (userDAL.UpdateFromAndToDateInCar(CarID, FromDate, ToDate))
            {
                
                return RedirectToAction("BookingList");
            }

            return RedirectToAction("BookingList");
        }
        #endregion

        

        #region profile
        public IActionResult Profile()
        {
            return View();
        }
        #endregion

        #region Get Car Page
        public IActionResult GetCarPage(string CityName,int CityID)
        {
            TempData["CityID"] = CityID;
            TempData["CityName"] = userDAL.CityName(CityID);
            return View();
        }
        #endregion

        #region Filter
        public IActionResult Filter(CarFilterModelUser modelCarFilter, string? FromDate, string? ToDate,int CityID)
        {
            TempData["FromDate"] = FromDate;
            TempData["ToDate"] = ToDate;
            DataTable dt = userDAL.User_Filter(modelCarFilter,CityID);
            return View("CarList", dt);
        }
        #endregion

        public IActionResult Rating(RatingModel modelRating,int CarID)
        {
            if (ModelState.IsValid)
            {
                if (userDAL.Rating(modelRating))
                {

                    return RedirectToAction("BookingList");
                }
            }
            return View("BookingList");
        } 

        public ActionResult RatingPage()
        {
            return PartialView();
        }
    }
}

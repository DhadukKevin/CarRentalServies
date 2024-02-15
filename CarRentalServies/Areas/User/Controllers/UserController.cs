using CarRentalServies.Areas.Admin.DAL;
using CarRentalServies.Areas.User.DAL;
using CarRentalServies.Areas.User.Models;
using CarRentalServies.BAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;



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
            CarModel model = new CarModel();
            model = userDAL.CarByID(CarID);
            return View("CarDetailPage", model);
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
        public IActionResult BookinSave(int CarID, int UserID, string FromDate, string ToDate,string Email)
        {
            if (userDAL.BookingSave(CarID, UserID, FromDate, ToDate))
            {
                if (userDAL.UpdateFromAndToDateInCar(CarID, FromDate, ToDate))
                {
                    //userDAL.SendEmail(Email);
                    return RedirectToAction("BookingList");
                }

            }
            return RedirectToAction("BookingList");
        }
        #endregion

        #region Booking List
        public IActionResult BookingList()
        {
            DataTable dataTable = userDAL.BookinghList();
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

        
        public IActionResult Filter(CarFilterModelUser modelCarFilter)
        {
            DataTable dt = userDAL.User_Filter(modelCarFilter);
            return View("CarList", dt);
        }
    }
}

using CarRentalServies.Areas.Admin.DAL;
using CarRentalServies.Areas.User.DAL;
using CarRentalServies.Areas.User.Models;
using CarRentalServies.BAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Net.Mail;
using System.Net;
using CarRentalServies.Models;

namespace CarRentalServies.Areas.User.Controllers
{

    [Area("User")]
    [Route("User/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IEmailService _emailService;

        Admin_DAL adminDal = new Admin_DAL();
        AddressBook_DAL addDal = new AddressBook_DAL();
        public UserController(IEmailService emailService)
        {
            _emailService = emailService;
        }

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
        public IActionResult CarList(int? cityID, string FromDate, string ToDate)
        {
            TempData["FromDate"] = FromDate;
            TempData["ToDate"] = ToDate;
            TempData["CityID"] = cityID;

            ViewBag.StateList = addDal.StateDropDown();
            ViewBag.CityList = addDal.CityDropDown();
            ViewBag.TransmissionList = adminDal.TransmissionDropDown();
            ViewBag.FuelList = adminDal.FuelDropDown();
            ViewBag.CarTypeList = adminDal.CarTypeDropDown();

            DataTable dataTable = userDAL.CarFilterByCity(cityID);

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
            DataTable dt1 = new DataTable();
            TempData["RatingCount"] = userDAL.RatingCount(CarID);
            var viewModel = new MyViewModel
            {
                modelCar = userDAL.CarByID(CarID),
                dt = userDAL.FeatureByCarID(CarID),
                dt1 = userDAL.RatingByCarID(CarID)
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

            ViewBag.StateList = addDal.StateDropDown();
            ViewBag.CityList = addDal.CityDropDown();
            ViewBag.TransmissionList = adminDal.TransmissionDropDown();
            ViewBag.FuelList = adminDal.FuelDropDown();
            ViewBag.CarTypeList = adminDal.CarTypeDropDown();

            DataTable dataTable = userDAL.CarByCityIDFromDateToDate(CityID, Convert.ToDateTime(FromDate), Convert.ToDateTime(ToDate));
            return View("CarList", dataTable);
        }
        #endregion

        #region BookingSave
        [CheckAccess]
        public async Task<IActionResult> BookinSave(int CarID, int UserID, string FromDate, string ToDate, string TotalFare)
        {
            if (userDAL.BookingSave(CarID, UserID, FromDate, ToDate, TotalFare))
            {
                if (userDAL.UpdateFromAndToDateInCar(CarID, FromDate, ToDate))
                {
                    CarModel model = new CarModel();
                    model = userDAL.CarByID(CarID);
                    string userName = CV.Name().ToString();
                    string userEmail = CV.Email().ToString();
                    string startDate = model.FromDate.ToString();
                    string endDate = model.ToDate.ToString();
                    string CarName = model.CarName.ToString();
                    string licensePlate = model.LicensePlate.ToString();
                    string contactEmail = "support@gmail.com";
                    string contactPhoneNumber = "+91 9087563421";
                    string companyName = "CarBook";
                    string mailBody = $@"
                                <p>Dear User, {userName}</p>
                                <p>We're thrilled to inform you that your car booking has been successfully confirmed!</p>
                                <h3>Booking Details:</h3>
                                <ul>
                                    <li><strong>From:</strong> {startDate}</li>
                                    <li><strong>To:</strong> {endDate}</li>
                                </ul>
                                <h3>Car Information:</h3>
                                <ul>
                                    <li><strong>Car Name:</strong> {CarName}</li>
                                    <li><strong>License Plate:</strong> {licensePlate}</li>
                                </ul>
                                <p>If you have any questions or need further assistance, feel free to reach out to our customer support team at {contactEmail} or {contactPhoneNumber}.</p>
                                <p>Thank you for choosing our service. We look forward to serving you!</p>
                                <p>Best regards,<br/>{companyName}</p>";
                    await _emailService.SendEmailAsync(@CV.Email().ToString(), "Car Booking Confirmation", mailBody);

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
        public IActionResult GetCarPage(string CityName, int CityID)
        {
            TempData["CityID"] = CityID;
            TempData["CityName"] = userDAL.CityName(CityID);
            return View();
        }
        #endregion

        #region Filter
        public IActionResult Filter(CarFilterModelUser modelCarFilter, string? FromDate, string? ToDate, int CityID)
        {
            TempData["FromDate"] = FromDate;
            TempData["ToDate"] = ToDate;
            DataTable dt = userDAL.User_Filter(modelCarFilter, CityID);
            return View("CarList", dt);
        }
        #endregion

        #region Rating Car
        public IActionResult RatingCar(int CarID, string Rating, string Review)
        {

            if (userDAL.Rating(Rating, Review, CarID))
            {

                return RedirectToAction("BookingList");
            }

            return RedirectToAction("BookingList");
        }
        #endregion

       
    }
}

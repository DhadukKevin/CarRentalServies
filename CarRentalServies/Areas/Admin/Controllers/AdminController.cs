using CarRentalServies.Areas.Admin.DAL;
using CarRentalServies.Areas.Admin.Models;
using CarRentalServies.BAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

namespace CarRentalServies.Areas.Admin.Controllers
{
    [CheckAccess]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class AdminController : Controller
    {
        Admin_DAL adminDal = new Admin_DAL();
        AddressBook_DAL addDal = new AddressBook_DAL();

        #region Index
        public IActionResult Index()
        {
            ViewBag.CarCount = adminDal.CarCount();
            ViewBag.UserCount = adminDal.UserCount();
            ViewBag.CityCount = adminDal.CityCount();
            DataTable dataTable = adminDal.CountTable();
            return View("Index",dataTable);
        }
        #endregion

        #region CarList
        public IActionResult CarList()
        {
            DataTable dataTable = adminDal.CarSelectAll();
            ViewBag.StateList = addDal.StateDropDown();
            ViewBag.CityList = addDal.CityDropDown();
            ViewBag.TransmissionList = adminDal.TransmissionDropDown();
            ViewBag.FuelList = adminDal.FuelDropDown();
            ViewBag.CarTypeList = adminDal.CarTypeDropDown();
            return View(dataTable);
        }
        #endregion

        #region Car Delete
        public IActionResult CarDelete(int CarID)
        {
            bool isSuccess = adminDal.CarDelete(CarID);

            if (isSuccess)
            {
                return RedirectToAction("CarList");
            }
            return RedirectToAction("CarList");
        }
        #endregion

        #region CarSave
        public IActionResult CarSave(CarModel modelCar)
        {
            if (ModelState.IsValid)
            {
                if (adminDal.CarSave(modelCar))
                {
                    return RedirectToAction("CarList");
                }

            }
            return View("CarAddEdit");
        }
        #endregion

        #region CarAddEdit
        public IActionResult CarAddEdit(int CarID)
        {
            CarModel modelCar = adminDal.CarByID(CarID);

            if (modelCar != null)
            {
                ViewBag.CarTypeList = adminDal.CarTypeDropDown();
                ViewBag.FuelList = adminDal.FuelDropDown();
                ViewBag.TransmissionList = adminDal.TransmissionDropDown();
                ViewBag.CityList = adminDal.CityDropDown();
                TempData["PageTitle"] = "Car Edit Page";
                return View("CarAddEdit", modelCar);
            }
            else
            {
                ViewBag.CarTypeList = adminDal.CarTypeDropDown();
                ViewBag.FuelList = adminDal.FuelDropDown();
                ViewBag.TransmissionList = adminDal.TransmissionDropDown();
                ViewBag.CityList = adminDal.CityDropDown();
                TempData["PageTitle"] = "Car Add Page";
                return View("CarAddEdit");
            }
        }
        #endregion

        #region UserList
        public IActionResult UserList()
        {
            DataTable dataTable = adminDal.UserSelectAll();
            ViewBag.StateList = addDal.StateDropDown();
            ViewBag.CityList = addDal.CityDropDown();
            return View(dataTable);
        }
        #endregion

        #region Car Delete
        public IActionResult UserDelete(int UserID)
        {
            bool isSuccess = adminDal.UserDelete(UserID);

            if (isSuccess)
            {
                return RedirectToAction("UserList");
            }
            return RedirectToAction("UserList");
        }
        #endregion

        #region UserSave
        public IActionResult UserSave(UserModel modelUser)
        {
            if (ModelState.IsValid)
            {
                if (adminDal.UserSave(modelUser))
                {

                    return RedirectToAction("Profile");
                }
            }
            return View("UserAddEdit");
        }
        #endregion

        #region UserAddEdit
        public IActionResult UserAddEdit(int UserID)
        {
            UserModel modelUser = adminDal.UserByID(UserID);

            if (modelUser != null)
            {
                ViewBag.CityList = adminDal.CityDropDown();
                return View("UserAddEdit", modelUser);
            }
            else
            {
                ViewBag.CityList = adminDal.CityDropDown();
                return View("UserAddEdit");
            }
        }
        #endregion

        #region Profile
        public IActionResult Profile()
        {
            ViewBag.CityList = adminDal.CityDropDown();
            return View();
        }
        #endregion

        #region User Filter
        public IActionResult UserFilter(UserFilterModel filterModel)
        {
            DataTable dataTable = adminDal.UserFilter(filterModel);
            ViewBag.StateList = addDal.StateDropDown();
            ViewBag.CityList = addDal.CityDropDown();
            ModelState.Clear();
            return View("UserList", dataTable);
        }
        #endregion

        #region Car Filter
        public IActionResult CarFilter(CarFilterModel filterModel)
        {
            DataTable dataTable = adminDal.CarFilter(filterModel);
            ViewBag.StateList = addDal.StateDropDown();
            ViewBag.CityList = addDal.CityDropDown();
            ViewBag.TransmissionList = adminDal.TransmissionDropDown();
            ViewBag.FuelList = adminDal.FuelDropDown();
            ViewBag.CarTypeList = adminDal.CarTypeDropDown();
            ModelState.Clear();
            return View("CarList", dataTable);
        }
        #endregion

    }
}

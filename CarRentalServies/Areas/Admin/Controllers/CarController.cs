using CarRentalServies.Areas.Admin.DAL;
using CarRentalServies.Areas.Admin.Models;
using CarRentalServies.BAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Data;

namespace CarRentalServies.Areas.Admin.Controllers
{
    [CheckAccess]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class CarController : Controller
    {
        Car_DAL carDal = new Car_DAL();
        public IActionResult Index()
        {
            return View();
        }

        #region Car Type List
        public IActionResult CarTypeList()
        {
            DataTable dataTable = carDal.CarTypeSelecttAll();
            return View(dataTable);
        }
        #endregion

        #region Car Type Delete
        public IActionResult CarTypeDelete(int CarTypeID)
        {
            bool isSuccess = carDal.CarTypeDelete(CarTypeID);

            if (isSuccess)
            {
                return RedirectToAction("CarTypeList");
            }
            return RedirectToAction("CarTypeList");
        }
        #endregion

        #region CarTypeSave
        public IActionResult CarTypeSave(CarTypeModel modelCartype)
        {
            if (ModelState.IsValid)
            {
                if (carDal.CarTypeSave(modelCartype))
                {
                    return RedirectToAction("CarTypeList");
                }

            }
            return View("CarTypeAddEdit");
        }
        #endregion

        #region CarTypeAddEdit
        public IActionResult CarTypeAddEdit(int CarTypeID)
        {
            CarTypeModel modelCartype = carDal.CarTypeByID(CarTypeID);

            if (modelCartype != null)
            {
                TempData["PageTitle"] = "Country Edit Page";
                return View("CarTypeAddEdit", modelCartype);
            }
            else
            {
                TempData["PageTitle"] = "Country Add Page";
                return View("CarTypeAddEdit");
            }
        }
        #endregion

        #region Fuel Type Select All
        public IActionResult FuelTypeList()
        {
            DataTable dataTable = carDal.FuelTypeSelecttAll();
            return View(dataTable);
        }
        #endregion

        #region Fuel Type Delete
        public IActionResult FuelTypeDelete(int FuelID)
        {
            bool isSuccess = carDal.FuelTypeDelete(FuelID);

            if (isSuccess)
            {
                return RedirectToAction("FuelTypeList");
            }
            return RedirectToAction("FuelTypeList");
        }
        #endregion

        #region FuelTypeSave
        public IActionResult FuelTypeSave(FuelTypeModel modelFuelType)
        {
            if (ModelState.IsValid)
            {
                if (carDal.FuelTypeSave(modelFuelType))
                {
                    return RedirectToAction("FuelTypeList");
                }

            }
            return View("FuelTypeAddEdit");
        }
        #endregion

        #region FuelTypeAddEdit
        public IActionResult FuelTypeAddEdit(int FuelID)
        {
            FuelTypeModel modelFueltype = carDal.FuelTypeByID(FuelID);

            if (modelFueltype != null)
            {
                TempData["PageTitle"] = "Country Edit Page";
                return View("FuelTypeAddEdit", modelFueltype);
            }
            else
            {
                TempData["PageTitle"] = "Country Add Page";
                return View("FuelTypeAddEdit");
            }
        }
        #endregion

        #region Transmission Select All
        public IActionResult TransmissionList()
        {
            DataTable dataTable = carDal.TransmissionSelecttAll();
            return View(dataTable);
        }
        #endregion

        #region Transmission Delete
        public IActionResult TransmissionDelete(int TransmissionID)
        {
            bool isSuccess = carDal.TransmissionDelete(TransmissionID);

            if (isSuccess)
            {
                return RedirectToAction("TransmissionList");
            }
            return RedirectToAction("TransmissionList");
        }
        #endregion

        #region Transmission Save
        public IActionResult TransmissionSave(TransmissionModel modelTransmission)
        {
            if (ModelState.IsValid)
            {
                if (carDal.TransmissionSave(modelTransmission))
                {
                    return RedirectToAction("TransmissionList");
                }

            }
            return View("TransmissionAddEdit");
        }
        #endregion

        #region Transmission AddEdit
        public IActionResult TransmissionAddEdit(int TransmissionID)
        {
            TransmissionModel modelTransmission = carDal.TransmissionByID(TransmissionID);

            if (modelTransmission != null)
            {
                TempData["PageTitle"] = "Country Edit Page";
                return View("TransmissionAddEdit", modelTransmission);
            }
            else
            {
                TempData["PageTitle"] = "Country Add Page";
                return View("TransmissionAddEdit");
            }
        }
        #endregion
    }
}

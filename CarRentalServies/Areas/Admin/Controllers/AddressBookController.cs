using CarRentalServies.Areas.Admin.DAL;
using CarRentalServies.Areas.Admin.Models;
using CarRentalServies.BAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CarRentalServies.Areas.Admin.Controllers
{
    [CheckAccess]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class AddressBookController : Controller
    {
        AddressBook_DAL addDal = new AddressBook_DAL();
        public IActionResult Index()
        {
            return View();
        }
        
        #region CountryList
        public IActionResult CountryList()
        {
            DataTable dataTable = addDal.CountrySelecttAll();
            return View(dataTable);
        }
        #endregion

        #region Country Delete
        public IActionResult CountryDelete(int CountryID)
        {
            bool isSuccess = addDal.CountryDelete(CountryID);

            if (isSuccess)
            {
                return RedirectToAction("CountryList");
            }
            return RedirectToAction("CountryList");
        }
        #endregion

        #region CountrySave
        public IActionResult CountrySave(CountryModel modelCountry)
        {
            if (ModelState.IsValid)
            {
                if (addDal.CountrySave(modelCountry))
                {
                    return RedirectToAction("CountryList");
                }

            }
            return View("CountryAddEdit");
        }
        #endregion

        #region CountryAddEdit
        public IActionResult CountryAddEdit(int CountryID)
        {
            CountryModel modelCountry = addDal.CountryByID(CountryID);

            if (modelCountry != null)
            {
                TempData["PageTitle"] = "Country Edit Page";
                return View("CountryAddEdit", modelCountry);
            }
            else
            {
                TempData["PageTitle"] = "Country Add Page";
                return View("CountryAddEdit");
            }
        }
        #endregion

        #region StateList
        public IActionResult StateList()
        {
            DataTable dataTable = addDal.StateSelecttAll();
            ViewBag.CountryList = addDal.CountryDropDown();
            return View(dataTable);
        }
        #endregion

        #region State Delete
        public IActionResult StateDelete(int StateID)
        {
            bool isSuccess = addDal.StateDelete(StateID);

            if (isSuccess)
            {
                return RedirectToAction("StateList");
            }
            return RedirectToAction("StateList");
        }
        #endregion

        #region StateSave
        public IActionResult StateSave(StateModel modelState)
        {
            if (ModelState.IsValid)
            {
                if (addDal.StateSave(modelState))
                {
                    return RedirectToAction("StateList");
                }

            }
            return View("StateAddEdit");
        }
        #endregion

        #region StateAddEdit
        public IActionResult StateAddEdit(int StateID)
        {
            StateModel modelState = addDal.StateByID(StateID);

            if (modelState != null)
            {
                TempData["PageTitle"] = "Country Edit Page";
                ViewBag.CountryList = addDal.CountryDropDown();
                return View("StateAddEdit", modelState);
            }
            else
            {
                TempData["PageTitle"] = "Country Add Page";
                ViewBag.CountryList = addDal.CountryDropDown();
                return View("StateAddEdit");
            }
        }
        #endregion

        #region CityList
        public IActionResult CityList()
        {
            DataTable dataTable = addDal.CitySelecttAll();
            ViewBag.StateList = addDal.StateDropDown();
            ViewBag.CountryList = addDal.CountryDropDown();
            return View(dataTable);
        }
        #endregion

        #region City Delete
        public IActionResult CityDelete(int CityID)
        {
            bool isSuccess = addDal.CityDelete(CityID);

            if (isSuccess)
            {
                return RedirectToAction("CityList");
            }
            return RedirectToAction("CityList");
        }
        #endregion

        #region CitySave
        public IActionResult CitySave(CityModel modelCity)
        {
            if (ModelState.IsValid)
            {
                if (addDal.CitySave(modelCity))
                {
                    return RedirectToAction("CityList");
                }

            }
            return View("CityAddEdit");
        }
        #endregion

        #region CityAddEdit
        public IActionResult CityAddEdit(int CityID)
        {
            CityModel modelCity = addDal.CityByID(CityID);

            if (modelCity != null)
            {
                TempData["PageTitle"] = "Country Edit Page";
                ViewBag.StateList = addDal.StateDropDown();
                return View("CityAddEdit", modelCity);
            }
            else
            {
                TempData["PageTitle"] = "Country Add Page";
                ViewBag.StateList = addDal.StateDropDown();
                return View("CityAddEdit");
            }
        }
        #endregion

        #region Country Filter
        public IActionResult CountryFilter(CountryFilterModel filterModel)
        {
            DataTable dataTable = addDal.CountryFilter(filterModel);
            return View("CountryList",dataTable);
        }
        #endregion

        #region State Filter
        public IActionResult StateFilter(StateFilterModel filterModel)
        {
            DataTable dataTable = addDal.StateFilter(filterModel);
            ViewBag.CountryList = addDal.CountryDropDown();
            return View("StateList", dataTable);
        }
        #endregion

        #region City Filter
        public IActionResult CityFilter(CityFilterModel filterModel)
        {
            DataTable dataTable = addDal.CityFilter(filterModel);
            ViewBag.StateList = addDal.StateDropDown();
            ViewBag.CountryList = addDal.CountryDropDown();
            return View("CityList", dataTable);
        }
        #endregion
    }
}

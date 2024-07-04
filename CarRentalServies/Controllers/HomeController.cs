using CarRentalServies.Areas.User.DAL;
using CarRentalServies.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;

namespace CarRentalServies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        User_DAL userDAL = new User_DAL();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.CityList = userDAL.CityDropDown();
            DataTable dt = new DataTable();
            dt = userDAL.SelectTopCars();
            return View(dt);
        }
        public IActionResult Temp()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region About
        public IActionResult About()
        {
            return View();
        }
        #endregion
    }
}
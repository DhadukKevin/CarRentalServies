using System.ComponentModel.DataAnnotations;

namespace CarRentalServies.Areas.Admin.Models
{
    public class CarModel
    {
        public int? CarID { get; set; }
        public string? CarName { get; set; }
        public string? CarPhoto { get; set; }
        public int? TransmissionID { get; set; }
        public int? FuelID { get; set; }
        public int? CarTypeID { get; set; }
        public string? CarDetail { get; set; }
        public decimal? Kms { get; set; }
        public int? CityID { get; set; }
        public string? Location { get; set; }
        public decimal? Price { get; set; }
        public IFormFile? CarImage { get; set; }
    }

    public class CarFilterModel
    {
        public string? CarName { get; set; }
        public int? TransmissionID { get; set; }
        public int? FuelID { get; set; }
        public int? CarTypeID { get; set; }
        public int? CityID { get; set; }
        public int? StateID { get; set; }
    }

    public class CarTypeDropDownModel
    {
        public int CarTypeID { get; set; }
        public string CarTypeName { get; set; }
    }
    public class CarTypeModel
    {
        public int? CarTypeID { get; set; }
        public string? CarTypeName { get; set; }
        public int? SeatNumber { get; set; }
    }

    public class CityDropDownModel
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
    }
    public class FuelTypeDropDownModel
    {
        public int FuelID { get; set; }
        public string FuelTypeName { get; set; }
    }

    public class FuelTypeModel
    {
        public int? FuelID { get; set; }
        public string? FuelTypeName { get; set; }
    }

    public class TransmissionDropDownModel
    {
        public int TransmissionID { get; set; }
        public string TransmissionName { get; set; }
    }

    public class TransmissionModel
    {
        public int? TransmissionID { get; set; }
        public string? TransmissionName { get; set; }
    }
}

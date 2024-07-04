using System.ComponentModel.DataAnnotations;

namespace CarRentalServies.Areas.User.Models
{
    public class CarModel
    {
        public int? CarID { get; set; }
        [Required]
        public string? CarName { get; set; }
        public string? CarPhoto { get; set; }
        [Required]
        public int? TransmissionID { get; set; }
        public string? TransmissionName { get; set; }
        [Required]
        public int? FuelID { get; set; }
        public string? FuelName { get; set; }
        [Required]
        public int? CarTypeID { get; set; }
        public string? CarTypeName { get; set; }
        public int? SeatNumber { get; set; }
        [Required]
        public string? CarDetail { get; set; }
        [Required]
        public decimal? Kms { get; set; }
        [Required]
        public int? CityID { get; set; }
        public string? CityName { get; set; }
        public string? Location { get; set; }
        [Required]
        public decimal? Price { get; set; }

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? LicensePlate { get; set; }

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

    public class CarFilterModelUser
    {
        public string? CarName { get; set; }
        public int? TransmissionID { get; set; }
        public int? FuelID { get; set; }
        public int? CarTypeID { get; set; }
        public int? SeatNumber { get; set; }
        public int? CityID { get; set; }
        
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

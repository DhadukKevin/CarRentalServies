using System.ComponentModel.DataAnnotations;

namespace CarRentalServies.Areas.Admin.Models
{
    public class CountryModel
    {
        public int? CountryID { get; set; }

        [Required]
        public string? CountryName { get; set; }

        [Required]
        public string? CountryCode { get; set; }

    }

    public class CountryDropDownModel
    {
        public int? CountryID { get; set; }
        public string? CountryName { get; set; }
    }

    public class CountryFilterModel
    {
        public string? CountryName { get; set; }

        public string? CountryCode { get; set; }

    }
}

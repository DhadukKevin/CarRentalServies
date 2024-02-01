using System.ComponentModel.DataAnnotations;

namespace CarRentalServies.Areas.Admin.Models
{
    public class UserModel
    {
        public int? UserID { get; set; }
        [Required]
		public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public int? CityID { get; set; }
        public string? ProfilePhoto { get; set; }
        [Required]
        public string? MobileNo { get; set; }
    }

    public class UserFilterModel
    {
        public string? Name { get; set; }
        public int? CityID { get; set; }
        public int? StateID { get; set; }
    }
}

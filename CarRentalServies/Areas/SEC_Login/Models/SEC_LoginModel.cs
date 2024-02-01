using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarRentalServies.Areas.SEC_Login.Models
{
    public class SEC_LoginModel
    {
        public int UserID { get; set; }

        [Required]
        [DisplayName("User Name")]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public int CityID { get; set; }
        [Required]
        public string MobileNo { get; set; }
        public string? ProfilePhoto { get; set; }
    }

    public class SEC_RegistrationModel
    {
        [Required]
        [DisplayName("User Name")]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }

        public int CityID { get; set; }
        //[Required]
        //public string MobileNo { get; set; }    
        //public string? ProfilePhoto { get; set;}

    }
}


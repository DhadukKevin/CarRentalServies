namespace CarRentalServies.Areas.Admin.Models
{
    public class StateModel
    {
        public int? StateID { get; set; }
        public string? StateName { get; set; }
        public string? StateCode { get; set; }
        public int? CountryID { get; set; }

    }

    public class StateDropDownModel
    {
        public int? StateID { get; set; }
        public string? StateName { get; set; }
    }

    public class StateFilterModel
    {
        public string? StateName { get; set; }

        public int? CountryID { get; set;}
    }
}

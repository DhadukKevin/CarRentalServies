﻿namespace CarRentalServies.Areas.Admin.Models
{
    public class CityModel
    {
        public int? CityID { get; set; }
        public string? CityName { get; set; }
        public string? CityCode { get; set; }
        public int? StateID { get; set; }


    }

    public class CityFilterModel
    {
        public string? CityName { get; set; }
        public int? StateID { get; set; }
        public int? CountryID { get; set; }
    }
}
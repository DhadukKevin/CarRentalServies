namespace CarRentalServies.Areas.Admin.Models
{
    public class DashBoardModel
    {
        public int CityCount { get; set; }
        public int CarCount { get; set; }
        public int UserCount { get; set; }


    }
    public class DashBoardModelCount
    {   
        public int UserCountByCity { get; set; }
        public int CarCountByCity { get; set; }
        public string CityName { get; set; }
    }
}

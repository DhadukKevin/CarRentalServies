namespace CarRentalServies.Areas.User.Models
{
    public class RatingModel
    {
        public int? RatingID { get; set; }
        public int? UserID { get; set; }
        public int? CarID { get; set; }
        public string? Review { get; set; }
        public Decimal? Rating { get; set; }

    }
}

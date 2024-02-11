namespace CarRentalServies.BAL
{
    public class CV
    {
        private static IHttpContextAccessor _HttpContextAccessor;
            static CV()
            {
                _HttpContextAccessor = new HttpContextAccessor();
            }

        public static int? UserID()
        {
            return Convert.ToInt32(_HttpContextAccessor.HttpContext.Session.GetString("UserID"));
        }

        public static string Name()
        {
            return _HttpContextAccessor.HttpContext.Session.GetString("Name");
        }

        public static string ProfilePhoto()
        {
            return _HttpContextAccessor.HttpContext.Session.GetString("ProfilePhoto");
        }

        public static string Email()
        {
            return _HttpContextAccessor.HttpContext.Session.GetString("Email");
        }

        public static string IsAdmin()
        {
            return _HttpContextAccessor.HttpContext.Session.GetString("IsAdmin");
        }

        public static string MobileNo()
        {
            return _HttpContextAccessor.HttpContext.Session.GetString("MobileNo");
        }

        public static string CityName()
        {
            return _HttpContextAccessor.HttpContext.Session.GetString("CityName");
        }
    }
}

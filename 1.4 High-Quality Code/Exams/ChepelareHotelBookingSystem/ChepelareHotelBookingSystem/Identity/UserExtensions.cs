namespace ChepelareHotelBookingSystem.Identity
{
    using Enums;
    using Models;

    public static class UserExtensions
    {
        public static bool IsInRole(this User user, Roles role)
        {
            return user.Role == role;
        }
    }
}

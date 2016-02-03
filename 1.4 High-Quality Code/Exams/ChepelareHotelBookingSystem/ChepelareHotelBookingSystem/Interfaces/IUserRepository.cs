namespace ChepelareHotelBookingSystem.Interfaces
{
    using Models;

    public interface IUserRepository : IRepository<User>
    {
        User GetByUsername(string username);
    }
}
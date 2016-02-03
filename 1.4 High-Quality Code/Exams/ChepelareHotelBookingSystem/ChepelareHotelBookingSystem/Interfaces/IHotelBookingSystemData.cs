namespace ChepelareHotelBookingSystem.Interfaces
{
    using Models;

    public interface IHotelBookingSystemData
    {
        IUserRepository RepositoryWithUsers { get; }

        IRepository<Venue> RepositoryWithVenues { get; }

        IRepository<Room> RepositoryWithRooms { get; }

        IRepository<Booking> RepositoryWithBookings { get; }
    }
}
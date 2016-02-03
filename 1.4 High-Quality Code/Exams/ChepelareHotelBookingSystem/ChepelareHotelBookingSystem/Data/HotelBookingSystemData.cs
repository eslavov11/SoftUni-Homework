namespace ChepelareHotelBookingSystem.Data
{
    using ChepelareHotelBookingSystem.Interfaces;
    using Models;

    public class HotelBookingSystemData : IHotelBookingSystemData
    {
        public HotelBookingSystemData()
        {
            this.RepositoryWithUsers = new UserRepository();
            this.RepositoryWithVenues = new Repository<Venue>();
            this.RepositoryWithRooms = new Repository<Room>();
            this.RepositoryWithBookings = new Repository<Booking>();
        }

        public IUserRepository RepositoryWithUsers { get; private set; }

        public IRepository<Venue> RepositoryWithVenues { get; set; }

        public IRepository<Room> RepositoryWithRooms { get; set; }

        public IRepository<Booking> RepositoryWithBookings { get; set; }
    }
}

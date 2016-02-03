namespace ChepelareHotelBookingSystem.Controllers
{
    using System;

    using ChepelareHotelBookingSystem.Enums;
    using ChepelareHotelBookingSystem.Infrastructure;
    using ChepelareHotelBookingSystem.Interfaces;
    using ChepelareHotelBookingSystem.Views.Shared;

    using Models;

    public class VenuesController : Controller
    {
        public VenuesController(IHotelBookingSystemData data, User user)
            : base(data, user)
        {
        }

        public IView All()
        {
            var venues = this.Data.RepositoryWithVenues.GetAll();
            return this.View(venues);
        }

        public IView Details(int id)
        {
            this.Authorize(Roles.User, Roles.VenueAdmin);
            var venue = this.Data.RepositoryWithVenues.Get(id);
            if (venue == null)
            {
                return this.NotFound(
                    string.Format("The venue with ID {0} does not exist.", id));
            }

            return this.View(venue);
        }

        public IView Rooms(int id)
        {
            var venue = this.Data.RepositoryWithVenues.Get(id);

            if (venue == null)
            {
                return new Error(string.Format("The venue with ID {0} does not exist.", id));
            }

            return this.View(venue);
        }

        public IView Add(string name, string address, string description)
        {
            var newVenue = new Venue(name, address, description, this.CurrentUser);
            this.Data.RepositoryWithVenues.Add(newVenue);
            return this.View(newVenue);
        }
    }
}
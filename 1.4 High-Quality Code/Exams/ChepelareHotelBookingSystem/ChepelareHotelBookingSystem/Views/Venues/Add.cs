namespace ChepelareHotelBookingSystem.Views.Venues
{
    using System.Text;

    using ChepelareHotelBookingSystem.Infrastructure;
    using Models;

    public class Add : View
    {
        public Add(Venue venue)
            : base(venue)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var venue = this.Model as Venue;
            viewResult.AppendFormat("The venue {0} with ID {1} has been created successfully.", venue.Name, venue.Id).AppendLine();
        }
    }
}
namespace ChepelareHotelBookingSystem.Views.Rooms
{
    using System.Text;

    using ChepelareHotelBookingSystem.Infrastructure;
    using Models;

    public class AddPeriod : View
    {
        public AddPeriod(Room room)
            : base(room)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var room = this.Model as Room;
            viewResult.AppendFormat(
                "The period has been added to room with ID {0}.", 
                room.Id).AppendLine();
        }
    }
}
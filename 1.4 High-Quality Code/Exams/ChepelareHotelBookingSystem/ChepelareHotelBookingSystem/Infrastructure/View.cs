namespace ChepelareHotelBookingSystem.Infrastructure
{
    using System.Text;

    using ChepelareHotelBookingSystem.Interfaces;

    public abstract class View : IView
    {
        public View(object model)
        {
            this.Model = this.Model;
        }

        public object Model { get; private set; }

        public string Display()
        {
            var viewResult = new StringBuilder();
            this.BuildViewResult(viewResult);
            return viewResult.ToString().Trim();
        }

        protected abstract void BuildViewResult(StringBuilder viewResult);
    }
}

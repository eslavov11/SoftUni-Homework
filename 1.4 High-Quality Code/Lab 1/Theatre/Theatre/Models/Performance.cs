namespace Theatre.Models
{
    using System;

    public class Performance : IComparable<Performance>
    {
        public Performance(string theatreName, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price)
        {
            this.TheatreName = theatreName;
            this.PerformanceTitle = performanceTitle;
            this.StartDateTime = startDateTime;
            this.Duration = duration; this.Price = price;
        }

        public string TheatreName { get; }

        public string PerformanceTitle { get; }

        public DateTime StartDateTime { get; set; }

        public TimeSpan Duration { get; }

        public decimal Price { get; }

        int IComparable<Performance>.CompareTo(Performance otherBuoiDien)
        {
            int tmp = this.StartDateTime.CompareTo(otherBuoiDien.StartDateTime); return tmp;
        }

        public override string ToString()
        {
            string result = string.Format(
                "Performance(Theatre name: {0}; Performanc title: {1}; Start date time: {2}, duration: {3}, price: {4})",
                this.TheatreName,
                this.PerformanceTitle,
                this.StartDateTime.ToString("dd.MM.yyyy HH:mm"), 
                this.Duration.ToString("hh':'mm"), 
                this.Price.ToString("f2"));

            return result;
        }
    }
}

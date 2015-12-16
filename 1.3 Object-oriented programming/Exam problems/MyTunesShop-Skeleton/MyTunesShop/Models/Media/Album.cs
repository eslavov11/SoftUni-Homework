using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTunesShop.Interfaces;

namespace MyTunesShop.Models.Media
{
    public class Album : Media, IAlbum
    {
        public Album(string title, decimal price, string performerName, string genre, int year)
            : base(title, price)
        {
            this.Songs = new List<ISong>();
            this.Genre = genre;
            this.Year = year;
            this.PerformerName = performerName;
        }

        public string PerformerName { get; set; }

        public IPerformer Performer { get; set; }

        public string Genre { get; }

        public int Year { get; }

        public IList<ISong> Songs { get; }

        public void AddSong(ISong song)
        {
            this.Songs.Add(song);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.Append($"{this.Title} ({this.Year}) by {this.Performer}" + Environment.NewLine +
                          $"Genre: {this.Genre}, Price:${this.Price:F2}" + Environment.NewLine +
                          $"Supplies: WUT, Sold: WUT" + Environment.NewLine);

            if (this.Songs.Any())
            {
                output.AppendLine("Songs:");
                foreach (ISong song in Songs)
                {
                    output.AppendLine(song.Title + $"({song.Duration})");
                }
            }
            else
            {
                output.AppendLine("No Songs");
            }

            return output.ToString().TrimEnd('\r', '\n');
        }
    }
}

using System;
using System.Linq;
using System.Text;
using MyTunesShop.Interfaces;
using MyTunesShop.Models;
using MyTunesShop.Models.Media;
using MyTunesShop.Models.Performers;

namespace MyTunesShop.Core
{
    public class NewMyTunesEngine : MyTunesEngine
    {

        protected override void ExecuteInsertCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "song_to_album":
                    this.ExecuteInsertSongToAlbumCommand(commandWords);
                    break;
                case "member_to_band":
                    this.ExecuteInsertMemberToBandCommand(commandWords);
                    break;
                default:
                    base.ExecuteInsertCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteInsertPerformerCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "band":
                    this.ExecuteInsertBandCommand(commandWords);
                    break;
                default:
                    base.ExecuteInsertPerformerCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteInsertMediaCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "album":
                    var performer = this.performers.FirstOrDefault(p => p.Name == commandWords[5]);
                    if (performer == null)
                    {
                        this.Printer.PrintLine("The performer does not exist in the database.");
                        return;
                    }

                    var album = new Album(
                        commandWords[3],
                        decimal.Parse(commandWords[4]),
                        performer.Name,
                        commandWords[6],
                        int.Parse(commandWords[7]));
                    this.InsertAlbum(album, performer);
                    break;
                default:
                    base.ExecuteInsertMediaCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteSellCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "album":
                    var album = this.media.FirstOrDefault(s => s is IAlbum && s.Title == commandWords[2]);
                    if (album == null)
                    {
                        this.Printer.PrintLine("The album does not exist in the database.");
                        return;
                    }

                    int quantity = int.Parse(commandWords[3]);
                    this.mediaSupplies[album].Sell(quantity);
                    this.Printer.PrintLine("{0} items of album {1} successfully sold.", quantity, album.Title);
                    break;
                default:
                    base.ExecuteSellCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteSupplyCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "album":
                    var album = this.media.FirstOrDefault(s => s is IAlbum && s.Title == commandWords[2]);
                    if (album == null)
                    {
                        this.Printer.PrintLine("The album does not exist in the database.");
                        return;
                    }

                    int quantity = int.Parse(commandWords[3]);
                    this.mediaSupplies[album].Supply(quantity);
                    this.Printer.PrintLine("{0} items of album {1} successfully supplied.", quantity, album.Title);
                    break;
                default:
                    base.ExecuteSupplyCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteRateCommand(string[] commandWords)
        {
            var songToRate = (ISong)base.media.FirstOrDefault(x => x.Title == commandWords[2]);
            int rating = int.Parse(commandWords[3]);

            if (!(songToRate is IRateable))
            {
                throw new ArgumentException("The song must be rateable.");
            }

            songToRate.PlaceRating(rating);

            base.Printer.PrintLine("The rating has been placed successfully.");
        }

        protected override void ExecuteReportCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "performer":
                    this.ExecuteReportPerformerCommand(commandWords);
                    break;
                case "media":
                    this.ExecuteReportMediaCommand(commandWords);
                    break;
                default:
                    break;
            }
        }

        protected override void ExecuteReportPerformerCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "band":
                    var band = this.performers.FirstOrDefault(p => p is Band && p.Name == commandWords[3]) as Band;
                    if (band == null)
                    {
                        this.Printer.PrintLine("The band does not exist in the database.");
                        return;
                    }

                    this.Printer.PrintLine(this.GetBandReport(band));
                    break;
                default:
                    base.ExecuteReportPerformerCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteReportMediaCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "album":
                    var album = this.media.FirstOrDefault(s => s is IAlbum && s.Title == commandWords[3]) as IAlbum;
                    if (album == null)
                    {
                        this.Printer.PrintLine("The album does not exist in the database.");
                        return;
                    }

                    this.Printer.PrintLine(this.GetAlbumReport(album));
                    break;
                default:
                    base.ExecuteReportMediaCommand(commandWords);
                    break;
            }
        }

        //protected override string GetSongReport(ISong song)
        //{
        //    var songSalesInfo = this.mediaSupplies[song];

        //    string ratings = "0";
        //    if (song.Ratings.Count != 0)
        //    {
        //        ratings = $"{(song.Ratings.Sum()/song.Ratings.Count):F0}";
        //            //Convert.ToInt32(Math.Ceiling(Convert.ToDouble(song.Ratings.Sum() / (double)song.Ratings.Count)));
        //    }
            

        //    StringBuilder songInfo = new StringBuilder();
        //    songInfo.AppendFormat("{0} ({1}) by {2}", song.Title, song.Year, song.Performer.Name).AppendLine()
        //        .AppendFormat("Genre: {0}, Price: ${1:F2}", song.Genre, song.Price).AppendLine()
        //        .AppendFormat("Rating: {0}", ratings).AppendLine()
        //        .AppendFormat("Supplies: {0}, Sold: {1}", songSalesInfo.Supplies, songSalesInfo.QuantitySold);
        //    return songInfo.ToString();
        //}

        protected string GetAlbumReport(IAlbum album)
        {
            var songSalesInfo = this.mediaSupplies[album];
            StringBuilder songInfo = new StringBuilder();
            songInfo.AppendFormat("{0} ({1}) by {2}", album.Title, album.Year, album.Performer.Name).AppendLine()
                .AppendFormat("Genre: {0}, Price: ${1:F2}", album.Genre, album.Price).AppendLine()
                .AppendFormat("Supplies: {0}, Sold: {1}", songSalesInfo.Supplies, songSalesInfo.QuantitySold)
                .AppendLine();

            if (album.Songs.Any(x => x is ISong))
            {
                songInfo.AppendLine("Songs:");
                foreach (ISong song in album.Songs)
                {
                    songInfo.AppendLine(song.Title + " (" + song.Duration + ")");
                }
            }
            else
            {
                songInfo.AppendLine("No songs");
            }

            return songInfo.ToString().TrimEnd('\r', '\n');
        }

        protected override string GetSingerReport(Singer singer)
        {
            StringBuilder singerInfo = new StringBuilder();
            singerInfo.Append(singer.Name + ": ");
            if (singer.Songs.Any())
            {
                var songs = singer.Songs
                  .Select(s => s.Title)
                  .OrderBy(s => s);
                singerInfo.Append(string.Join("; ", songs));
            }
            else
            {
                singerInfo.Append("no songs");
            }

            return singerInfo.ToString();
        }

        protected string GetBandReport(IBand band)
        {
            var output = new StringBuilder();
            output.Append(band.Name + ": ");
            if (band.Members.Any())
            {
                output.Append( string.Join(", ", band.Members));
            }
            if (band.Songs.Any())
            {
                output.Append(Environment.NewLine + string.Join("; ", band.Songs.OrderBy(x => x.Title)));
            }
            else
            {
                output.Append(Environment.NewLine + "no songs");
            }

            return output.ToString();
        }

        private void ExecuteInsertSongToAlbumCommand(string[] commandWords)
        {
            if (!base.media.Any(x => x is IAlbum && x.Title == commandWords[2]))
            {
                throw new ArgumentException("The album does not exist in the database.");
            }

            if (!base.media.Any(x => x is ISong && x.Title == commandWords[3]))
            {
                throw new ArgumentException("The song does not exist in the database.");
            }

            var song = (ISong)base.media.FirstOrDefault(s => s.Title == commandWords[3] && s is ISong);

            //(base.media
            //    .Where(a => a.Title == commandWords[2] && a is IAlbum) as IAlbum)
            //    .AddSong(song);

            var album = (IAlbum) base.media.FirstOrDefault(a => a.Title == commandWords[2]);
            album.AddSong(song); 

            base.Printer.PrintLine($"The song {commandWords[3]} has been added to the album {commandWords[2]}.");
        }

        private void ExecuteInsertBandCommand(string[] commandWords)
        {
            var band = new Band(commandWords[3]);
            base.InsertPerformer(band);
        }

        private void InsertAlbum(Album album, IPerformer performer)
        {
            album.Performer = performer;
            this.media.Add(album);
            this.mediaSupplies.Add(album, new SalesInfo());
            // performer.Songs.Add(album);
            this.Printer.PrintLine("Album {0} by {1} added successfully", album.Title, performer.Name);
        }


        private void ExecuteInsertMemberToBandCommand(string[] commandWords)
        {
            if (!base.performers.Any(x => x is IBand && x.Name == commandWords[2]))
            {
                throw new ArgumentException("The band does not exist in the database.");
            }

            var singer = base.performers.FirstOrDefault(s => s.Name == commandWords[3]) ?? new Singer(commandWords[3]);

            //(base.performers
            //    .Where(album => album.Name == commandWords[2] && album is IBand) as IBand)
            //    .AddMember(singer.Name);

            var band = (IBand)base.performers.FirstOrDefault(a => a.Name == commandWords[2]);
            band.AddMember(singer.Name);

            base.Printer.PrintLine($"The member {commandWords[3]} has been added to the band {commandWords[2]}.");
        }

    }
}

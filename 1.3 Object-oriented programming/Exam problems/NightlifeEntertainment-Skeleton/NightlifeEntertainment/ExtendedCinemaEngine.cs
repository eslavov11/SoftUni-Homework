using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace NightlifeEntertainment
{
    public class ExtendedCinemaEngine : CinemaEngine
    {
        protected override void ExecuteInsertVenueCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "opera":
                    var opera = new OperaHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(opera);
                    break;
                case "sports_hall":
                    var sportsHall = new SportsHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(sportsHall);
                    break;
                case "concert_hall":
                    var concertHall = new ConcertHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(concertHall);
                    break;
                default:
                    base.ExecuteInsertVenueCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteInsertPerformanceCommand(string[] commandWords)
        {
            var venue = this.GetVenue(commandWords[5]);
            switch (commandWords[2])
            {
                case "theatre":
                    
                    var theatre = new Theatre(
                        commandWords[3],
                        decimal.Parse(commandWords[4]),
                        venue,
                        DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                    this.Performances.Add(theatre);
                    break;
                case "concert":
                    var concert = new Concert(
                        commandWords[3],
                        decimal.Parse(commandWords[4]),
                        venue,
                        DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                    this.Performances.Add(concert);
                    break;
                default:
                    base.ExecuteInsertPerformanceCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteSupplyTicketsCommand(string[] commandWords)
        {
            var venue = this.GetVenue(commandWords[2]);
            var performance = this.GetPerformance(commandWords[3]);
            switch (commandWords[1])
            {
                case "vip":
                    for (int i = 0; i < int.Parse(commandWords[4]); i++)
                    {
                        performance.AddTicket(new VIPTicket(performance));
                    }
                    break;
                case "student":
                    for (int i = 0; i < int.Parse(commandWords[4]); i++)
                    {
                        performance.AddTicket(new StudentTicket(performance));
                    }
                    break;
                default:
                    base.ExecuteSupplyTicketsCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteReportCommand(string[] commandWords)
        {
            var performance = this.GetPerformance(commandWords[1]);
            Output.AppendLine($"{performance.Name}:" +
                              $" {performance.Tickets.Count(st => st.Status == TicketStatus.Sold)}" +
                              $" ticket(s), total:" +
                              $" ${$"{performance.Tickets.Where(st => st.Status == TicketStatus.Sold).Sum(x => x.Price):F2}"}")
                              .AppendLine($"Venue: {performance.Venue.Name} ({performance.Venue.Location})")
                              .AppendLine($"Start time: {performance.StartTime}");
        }

        protected override void ExecuteSellTicketCommand(string[] commandWords)
        {
            base.ExecuteSellTicketCommand(commandWords);
        }

        protected override void ExecuteFindCommand(string[] commandWords)
        {
            var searchWord = commandWords[1].ToLower();
            DateTime currentTime = DateTime.Parse(commandWords[2] + " " + commandWords[3]);

            var foundPerformances = FindPerformances(currentTime)
                .Where(x => x.Name.ToLower().Contains(searchWord));

            var foundVenues = this.Venues
                .Where(x => x.Name.ToLower().Contains(searchWord))
                .OrderBy(x => x.Name);

            this.Output.AppendLine($"Search for \"{commandWords[1]}\"")
                .AppendLine("Performances:")
                .AppendLine(foundPerformances.Any()
                ? string.Join(Environment.NewLine, foundPerformances.Select(x => "-" + x.Name))
                : "no results")
                .AppendLine("Venues:");
            if (foundVenues.Any())
            {
                foreach (var venue in foundVenues)
                {
                    this.Output.AppendLine("-" + venue.Name);
                    var foundPerformancesInVenue = FindPerformances(currentTime)
                        .Where(p => p.Venue == venue);
                    if (foundPerformancesInVenue.Any())
                    {
                       this.Output.AppendLine(
                           string.Join(Environment.NewLine, foundPerformancesInVenue.Select(x => "--" + x.Name)));
                    }
                    else
                    {
                        this.Output.ToString().Substring(0, this.Output.Length - 2);
                    }
                }
            }
            else
            {
                this.Output.AppendLine("no results");
            }

        }

        private IEnumerable<IPerformance> FindPerformances(DateTime currentTime)
        {
            return this.Performances
                            .Where(x => x.StartTime >= currentTime)
                            .OrderBy(x => x.StartTime)
                            .ThenByDescending(x => x.BasePrice)
                            .ThenBy(x => x.Name);
        }
    }
}

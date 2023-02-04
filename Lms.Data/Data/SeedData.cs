using Bogus;
using Bogus.DataSets;
using Lms.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Data.Data
{
    public class SeedData
    {
        private readonly LmsDataContext? dbContext;

        public static void InitAsync(LmsDataContext dbContext)
        {
            dbContext = dbContext;

            //var idTour = 1;
            //var idGame = 1;
          
            if (!dbContext.Tournaments.Any())
            {
                var tournaments = new Faker<Tournament>()
                   //.RuleFor(u => u.Id, f => idTour++)
                   .RuleFor(t => t.Title, f => f.Lorem.Sentence())
                   .RuleFor(t => t.StartDate, f => f.Date.Past())              
                   .Generate(10);

                foreach (var tournament in tournaments)
                {
                    var games = new Faker<Game>()
                       //.RuleFor(u => u.Id, f => idGame++)
                       .RuleFor(g => g.Title, f => f.Lorem.Sentence())
                       .RuleFor(g => g.Time, f => f.Date.Between(tournament.StartDate, tournament.StartDate.AddDays(7)))
                       .Generate(new Random().Next(1, 5));

                    tournament.Games = new List<Game>();

                    foreach (var game in games)
                    {
                        game.TournamentId = tournament.Id;
                        tournament.Games.Add(game);
                    }

                    dbContext.Tournaments.Add(tournament);
                }

                dbContext.SaveChanges();
            }
        }
    }
}

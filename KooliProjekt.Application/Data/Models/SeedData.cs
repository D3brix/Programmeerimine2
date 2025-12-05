using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Data.Models
{
    public static class SeedData
    {
        public static async Task Generate(ApplicationDbContext db)
        {
            if (await db.Teams.AnyAsync())
                return;

            var teams = Enumerable.Range(1, 10)
                .Select(i => new Team { Title = $"Team {i}" })
                .ToList();

            await db.Teams.AddRangeAsync(teams);

            var tournaments = Enumerable.Range(1, 10)
                .Select(i => new Tournament { Title = $"Tournament {i}", Games = new List<Game>() })
                .ToList();

            await db.Tournaments.AddRangeAsync(tournaments);

            await db.SaveChangesAsync();

            var rnd = new Random();

            var games = Enumerable.Range(1, 10)
                .Select(i =>
                {
                    var team1 = teams[(i - 1) % teams.Count];
                    var team2 = teams[i % teams.Count];
                    var date = DateTime.Today.AddDays(i);
                    return new Game
                    {
                        Title = $"Game {i}",
                        Date = date,
                        Begins = date.AddHours(12),
                        Ends = date.AddHours(14),
                        Team1Score = rnd.Next(0, 6),
                        Team2Score = rnd.Next(0, 6),
                        Team1Id = team1.Id,
                        Team2Id = team2.Id,
                        TournamentId = tournaments[(i - 1) % tournaments.Count].Id
                    };
                })
                .ToList();

            await db.Games.AddRangeAsync(games);
            await db.SaveChangesAsync();

            var predictions = games.Select(g => new Prediction
            {
                GameId = g.Id,
                Team1Id = g.Team1Id,
                Team2Id = g.Team2Id,
                score1 = rnd.Next(0, 6),
                score2 = rnd.Next(0, 6),
                starttime = rnd.Next(0, 10000),
                endtime = rnd.Next(10001, 20000),
                points = rnd.Next(0, 10)
            }).ToList();

            await db.Predictions.AddRangeAsync(predictions);
            await db.SaveChangesAsync();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KooliProjekt.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        private static readonly string[] FirstNames = new[]
        {
            "Mari", "Jüri", "Kati", "Peeter", "Anne", "Tarmo", "Laura", "Karl"
        };

        private static readonly string[] LastNames = new[]
        {
            "Tamm", "Kask", "Sepp", "Mets", "Saar", "Rebane", "Vaher", "Karu"
        };

        private static readonly string[] Subjects = new[]
        {
            "Matemaatika", "Keemia", "Füüsika", "Bioloogia", "Ajalugu", "Inglise keel", "Eesti keel", "Geograafia"
        };

        private static readonly string[] Moods = new[]
        {
            "Heas tujus", "Natuke väsinud", "Väga motiveeritud", "Tööstressis", "Rahulik", "Energiline"
        };

        [HttpGet]
        public IEnumerable<Teachers> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Teachers
            {
                Id = index,
                FullName = $"{FirstNames[Random.Shared.Next(FirstNames.Length)]} {LastNames[Random.Shared.Next(LastNames.Length)]}",
                Subject = Subjects[Random.Shared.Next(Subjects.Length)],
                Mood = Moods[Random.Shared.Next(Moods.Length)],
                NextLesson = DateTime.Now.AddDays(Random.Shared.Next(1, 5))
            })
            .ToArray();
        }
    }

    public class Teachers
    {
        public int Id { get; set; }
        public string FullName { get; set; } = "";
        public string Subject { get; set; } = "";
        public string Mood { get; set; } = "";
        public DateTime NextLesson { get; set; }
    }
}


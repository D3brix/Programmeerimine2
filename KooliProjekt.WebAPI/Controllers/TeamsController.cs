using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KooliProjekt.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        private static readonly string[] TeamName = new[]
        {
            "Mari", "Jüri", "Kati", "Peeter", "Anne", "Tarmo", "Laura", "Karl"
        };

        private static readonly string[] Divison = new[]
        {
            "D1", "D2", "D3"
        };

        private static readonly string[] Moods = new[]
        {
            "Heas tujus", "Natuke väsinud", "Väga motiveeritud", "Tööstressis", "Rahulik", "Energiline"
        };

        [HttpGet]
        public IEnumerable<Teams> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Teams
            {
                Id = index,
                Team = $"{TeamName[Random.Shared.Next(TeamName.Length)]}",
                Divison = Divison[Random.Shared.Next(Divison.Length)],
                Moods = Moods[Random.Shared.Next(Moods.Length)],
            })
            .ToArray();
        }
    }

    public class Teams
    {
        public int Id { get; set; }
    public string Team { get; set; } = "";
    public string Divison { get; set; } = "";
    public string Moods { get; set; } = "";
}


}


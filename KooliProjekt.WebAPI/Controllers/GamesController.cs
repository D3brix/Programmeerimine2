using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace KooliProjekt.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private static readonly List<Game> _games = new();

        [HttpGet("get")]
        public IEnumerable<Game> GetAll() => _games;

        [HttpGet("get/{id}")]
        public ActionResult<Game> Get(int id)
        {
            var g = _games.FirstOrDefault(x => x.Id == id);
            return g is null ? NotFound() : Ok(g);
        }

        [HttpPost("save")]
        public ActionResult Save([FromBody] Game g)
        {
            g.Id = _games.Count + 1;
            _games.Add(g);
            return Ok(g);
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var g = _games.FirstOrDefault(x => x.Id == id);
            if (g is null) return NotFound();

            _games.Remove(g);
            return Ok(new { message = "Deleted", id });
        }
    }

    public class Game
    {
        public int Id { get; set; }
        public string HomeTeam { get; set; } = "";
        public string AwayTeam { get; set; } = "";
        public string Status { get; set; } = "";
    }
}

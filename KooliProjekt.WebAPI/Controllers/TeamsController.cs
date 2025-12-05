using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace KooliProjekt.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        private static readonly List<Team> _teams = new();

        [HttpGet("get")]
        public IEnumerable<Team> GetAll()
        {
            return _teams;
        }

        [HttpGet("get/{id}")]
        public ActionResult<Team> Get(int id)
        {
            var team = _teams.FirstOrDefault(t => t.Id == id);
            return team is null ? NotFound() : Ok(team);
        }

        [HttpPost("save")]
        public ActionResult Save([FromBody] Team team)
        {
            team.Id = _teams.Count + 1;
            _teams.Add(team);
            return Ok(team);
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var team = _teams.FirstOrDefault(t => t.Id == id);
            if (team is null)
                return NotFound();

            _teams.Remove(team);
            return Ok(new { message = "Deleted", id });
        }
    }

    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; } = "";
        public string Division { get; set; } = "";
        public string Mood { get; set; } = "";
    }
}

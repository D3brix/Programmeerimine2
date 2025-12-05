using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace KooliProjekt.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TournamentsController : ControllerBase
    {
        private static readonly List<Tournament> _tournaments = new();

        [HttpGet("get")]
        public IEnumerable<Tournament> GetAll() => _tournaments;

        [HttpGet("get/{id}")]
        public ActionResult<Tournament> Get(int id)
        {
            var t = _tournaments.FirstOrDefault(x => x.Id == id);
            return t is null ? NotFound() : Ok(t);
        }

        [HttpPost("save")]
        public ActionResult Save([FromBody] Tournament t)
        {
            t.Id = _tournaments.Count + 1;
            _tournaments.Add(t);
            return Ok(t);
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var t = _tournaments.FirstOrDefault(x => x.Id == id);
            if (t is null) return NotFound();

            _tournaments.Remove(t);
            return Ok(new { message = "Deleted", id });
        }
    }

    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Location { get; set; } = "";
    }
}

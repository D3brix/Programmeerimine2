using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace KooliProjekt.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PredictionsController : ControllerBase
    {
        private static readonly List<Prediction> _predictions = new();

        [HttpGet("get")]
        public IEnumerable<Prediction> GetAll() => _predictions;

        [HttpGet("get/{id}")]
        public ActionResult<Prediction> Get(int id)
        {
            var p = _predictions.FirstOrDefault(x => x.Id == id);
            return p is null ? NotFound() : Ok(p);
        }

        [HttpPost("save")]
        public ActionResult Save([FromBody] Prediction p)
        {
            p.Id = _predictions.Count + 1;
            _predictions.Add(p);
            return Ok(p);
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var p = _predictions.FirstOrDefault(x => x.Id == id);
            if (p is null) return NotFound();

            _predictions.Remove(p);
            return Ok(new { message = "Deleted", id });
        }
    }

    public class Prediction
    {
        public int Id { get; set; }
        public string Predictor { get; set; } = "";
        public string Outcome { get; set; } = "";
        public int Confidence { get; set; }
    }
}

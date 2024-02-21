using Microsoft.AspNetCore.Mvc;
using WebApiMeteo.Model;
using WebApiMeteo.Repository.Interfaces;

namespace WebApiMeteo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeteoController : ControllerBase
    {
        private readonly IMeteoRepository _meteoRepository;

        public MeteoController(IMeteoRepository meteoRepository)
        {
            _meteoRepository = meteoRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Meteo>> GetAll()
        {
            return Ok(_meteoRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public ActionResult<Meteo> Get(int id)
        {
            var meteo = _meteoRepository.GetAsync(id);
            if (meteo == null)
            {
                return NotFound();
            }
            return Ok(meteo);
        }

        [HttpPost]
        public ActionResult<Meteo> Create([FromBody] Meteo meteo)
        {
            if (meteo == null)
                return BadRequest();

            var createdMeteo = _meteoRepository.CreateAsync(meteo);
            return CreatedAtAction(nameof(Get), new { id = createdMeteo.Id }, createdMeteo);
        }

        [HttpPut("{id}")]
        public ActionResult<Meteo> Update(int id, [FromBody] Meteo meteo)
        {
            if (meteo == null || meteo.MeteoId != id)
                return BadRequest();

            var meteoToUpdate = _meteoRepository.GetAsync(id);
            if (meteoToUpdate == null)
                return NotFound();

            _meteoRepository.UpdateAsync(meteo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var meteoToDelete = _meteoRepository.GetAsync(id);
            if (meteoToDelete == null)
                return NotFound();

            _meteoRepository.DeleteAsync(meteoToDelete.Id);
            return NoContent();
        }
    }
}

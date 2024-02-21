using Microsoft.AspNetCore.Mvc;
using WebApiMeteo.Model;
using WebApiMeteo.Repository.Interfaces;

namespace WebApiMeteo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VilleController : ControllerBase
    {
        private readonly IVilleRepository _villeRepository;

        public VilleController(IVilleRepository villeRepository)
        {
            _villeRepository = villeRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Ville>> GetAll()
        {
            return Ok(_villeRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public ActionResult<Ville> Get(int id)
        {
            var ville = _villeRepository.GetAsync(id);
            if (ville == null)
            {
                return NotFound();
            }
            return Ok(ville);
        }

        [HttpPost]
        public ActionResult<Ville> Create([FromBody] Ville ville)
        {
            if (ville == null)
                return BadRequest();

            var createdVille = _villeRepository.CreateAsync(ville);
            return CreatedAtAction(nameof(Get), new { id = createdVille.Id }, createdVille);
        }

        [HttpPut("{id}")]
        public ActionResult<Ville> Update(int id, [FromBody] Ville ville)
        {
            if (ville == null || ville.Id != id)
                return BadRequest();

            var villeToUpdate = _villeRepository.GetAsync(id);
            if (villeToUpdate == null)
                return NotFound();

            _villeRepository.UpdateAsync(ville);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var villeToDelete = _villeRepository.GetAsync(id);
            if (villeToDelete == null)
                return NotFound();

            _villeRepository.DeleteAsync(villeToDelete.Id);
            return NoContent();
        }
    }
}

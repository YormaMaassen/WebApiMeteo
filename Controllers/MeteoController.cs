using Microsoft.AspNetCore.Mvc;
using WebApiMeteo.Model;
using WebApiMeteo.Process.Interfaces;
using WebApiMeteo.Request;

namespace WebApiMeteo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeteoController : ControllerBase
    {
        private readonly IGetMeteoProcess _getMeteoProcess;

        public MeteoController(IGetMeteoProcess getMeteoProcess)
        {
            _getMeteoProcess = getMeteoProcess;
        }

        [HttpPost]
        public ActionResult<Meteo> GetMeteo([FromBody] MeteoRequest req)
        {
            var res = _getMeteoProcess.GetMeteo(req.VilleId, req.Date);
            return Ok(res);
        }
    }
}

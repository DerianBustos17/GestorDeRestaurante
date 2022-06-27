using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestorDeRestaurante.SI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatillosController : ControllerBase
    {

        private readonly BS.IRepositorioDelRestaurante ElRepositorio;

        public PlatillosController(BS.IRepositorioDelRestaurante repositorio)
        {
            ElRepositorio = repositorio;
        }
        // GET: api/<PlatillosController>

        [HttpGet("ObtengaLaListaDePlatillos")]
        public IEnumerable<GestorDeRestaurante.Model.Platillos> ObtengaLaListaDePlatillos()
        {
            List<Model.Platillos> elResultado;
            elResultado = ElRepositorio.ObtengaLaListaDePlatillos();
            return elResultado;
        }

        // GET api/<PlatillosController>/5
        [HttpGet("ObtengaElMenuCompleto")]
        public Model.MenuCompleto ObtengaElMenuCompleto()
        {
            Model.MenuCompleto ElMenuCompleto;
            ElMenuCompleto = ElRepositorio.ObtengaElMenuCompleto();

            return ElMenuCompleto;
        }

        // POST api/<PlatillosController>
        [HttpPost("IngresePlatillo")]
        public IActionResult Post([FromBody] GestorDeRestaurante.Model.Platillos platillos)
        {
            if (ModelState.IsValid)
            {
                ElRepositorio.AgregueElPlatillo(platillos);
                return Ok(platillos);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        // PUT api/<PlatillosController>/5
        [HttpGet("ObtengaPlatillosPorId")]
        public GestorDeRestaurante.Model.Platillos ObtengaPlatillosPorId(int id)
        {
            Model.Platillos elResultado;
            elResultado = ElRepositorio.ObtenerPlatillosPorId(id);
            return elResultado;
        }


        [HttpPut("EditarPlatillo")]
        public IActionResult Put([FromBody] GestorDeRestaurante.Model.Platillos ElPlatillo)
        {

            if (ModelState.IsValid)
            {
                ElRepositorio.EditarLosPlatilos(ElPlatillo);
                return Ok(ElPlatillo);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        // DELETE api/<PlatillosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

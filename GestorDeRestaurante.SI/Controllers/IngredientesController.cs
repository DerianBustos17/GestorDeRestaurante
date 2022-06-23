using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestorDeRestaurante.SI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientesController : ControllerBase
    {
        private readonly BS.IRepositorioDelRestaurante ElRepositorio;

        public IngredientesController(BS.IRepositorioDelRestaurante repositorio)
        {
            ElRepositorio = repositorio;
        }

        // GET: api/<IngredientesController>
        [HttpGet("ObtengaLaLista")]
        public IEnumerable<GestorDeRestaurante.Model.Ingredientes> ObtengaLaListaDeIngredientes()
        {
            List<Model.Ingredientes> elResultado;
            elResultado = ElRepositorio.ObtengaLaListaDeIngredientes();
            return elResultado;
        }

        // GET api/<IngredientesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<IngredientesController>
        [HttpPost]
        public IActionResult Post([FromBody] GestorDeRestaurante.Model.Ingredientes ingredientes)
        {

            if (ModelState.IsValid)
            {
                ElRepositorio.AgregueIngredientes(ingredientes);
                return Ok(ingredientes);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        // PUT api/<IngredientesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<IngredientesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestorDeRestaurante.SI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientesDelMenuController : ControllerBase
    {
        private readonly BS.IRepositorioDelRestaurante ElRepositorio;

        public IngredientesDelMenuController(BS.IRepositorioDelRestaurante repositorio)
        {
            ElRepositorio = repositorio;
        }

        // GET: api/<IngredientesDelMenuController>
        [HttpGet("ObtengaElMenuParaAdministrarLosIngredientes")]
        public IEnumerable<GestorDeRestaurante.Model.Menu> ObtengaElMenuParaAdministrarLosIngredientes()
        {
            List<Model.Menu> elResultado;
            List<Model.Menu> laListaDelMenu;
            List<Model.MenuIngredientes> elMenuDeIngredientes;

            laListaDelMenu = ElRepositorio.ObtengaLaListaDePlatillos();
            elMenuDeIngredientes = ElRepositorio.ObtengaElMenuDeIngredientes();

            elResultado = ElRepositorio.ObtengaLaListaDelMenuParaIngredientes(laListaDelMenu, elMenuDeIngredientes);

            return elResultado;
        }

        // GET api/<IngredientesDelMenuController>/5
        [HttpGet("ObtengaLaListaDeIngredientesDeUnPlatilloPorId")]
        public IEnumerable<GestorDeRestaurante.Model.MenuIngredientes> ObtengaLaListaDeIngredientesDeUnPlatilloPorId(int id)
        {
            List<Model.MenuIngredientes> elResultado;

            elResultado = ElRepositorio.ObtengaLaListaDeIngredientesDeUnPlatilloPorId(id);

            return elResultado;
        }

        // POST api/<IngredientesDelMenuController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<IngredientesDelMenuController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<IngredientesDelMenuController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

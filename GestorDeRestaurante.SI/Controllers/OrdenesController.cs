using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestorDeRestaurante.SI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {
        private readonly BS.IRepositorioDelRestaurante ElRepositorio;

        public OrdenesController(BS.IRepositorioDelRestaurante repositorio)
        {
            ElRepositorio = repositorio;
        }

        // GET: api/<OrdenesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrdenesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrdenesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrdenesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdenesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

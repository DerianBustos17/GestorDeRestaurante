using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestorDeRestaurante.SI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedidasController : ControllerBase
    {
        private readonly BS.IRepositorioDelRestaurante ElRepositorio;

        public MedidasController(BS.IRepositorioDelRestaurante repositorio)
        {
            ElRepositorio = repositorio;
        }


        // GET: api/<MedidasController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MedidasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MedidasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MedidasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MedidasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

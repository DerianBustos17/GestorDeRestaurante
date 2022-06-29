﻿using Microsoft.AspNetCore.Mvc;

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
        public IEnumerable<GestorDeRestaurante.Model.Platillos> ObtengaElMenuParaAdministrarLosIngredientes()
        {
            List<Model.Platillos> elResultado;
            List<Model.Menu> laListaDelMenu;
            List<Model.MesaOrden> laListaDeOrdenes;

            laListaDelMenu = ElRepositorio.ObtengaLaListaDePlatillos();
            laListaDeOrdenes = ElRepositorio.ObtengaLaListaDeOrdenes();

            elResultado = ElRepositorio.ObtengaLaListaDelMenuParaIngredientes(laListaDelMenu, laListaDeOrdenes);

            return elResultado;
        }

        // GET api/<IngredientesDelMenuController>/5
        [HttpGet("ObtengaLaListaDeIngredientesDeUnPlatilloPorId")]
        public IEnumerable<GestorDeRestaurante.Model.IngredienteDelPlatillo> ObtengaLaListaDeIngredientesDeUnPlatilloPorId(int id)
        {
            List<Model.IngredienteDelPlatillo> elResultado;

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

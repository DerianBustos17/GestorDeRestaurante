﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace GestorDeRestaurante.UI.Controllers
{
    public class IngredienteDelMenuController : Controller
    {
        // GET: IngredienteDelMenuController
        public async Task<IActionResult> Index()
        {
            List<Model.Menu> laLista;

            try
            {
                var httpClient = new HttpClient();

                var response = await httpClient.GetAsync("https://localhost:7071/api/IngredientesDelMenu/ObtengaElMenuParaAdministrarLosIngredientes");
                string apiResponse = await response.Content.ReadAsStringAsync();
                laLista = JsonConvert.DeserializeObject<List<GestorDeRestaurante.Model.Menu>>(apiResponse);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(laLista);
        }



        // GET: IngredienteDelMenuController/Details/5
        public async Task<IActionResult> IngredientesDeUnPlatillo(int id)
        {
            List<Model.MenuIngredientes> laLista;

            try
            {
                var httpClient = new HttpClient();
                var query = new Dictionary<string, string>()
                {
                    ["id"] = id.ToString()
                };

                var uri = QueryHelpers.AddQueryString("https://localhost:7071/api/IngredientesDelMenu/ObtengaLaListaDeIngredientesDeUnPlatilloPorId", query);
                var response = await httpClient.GetAsync(uri);
                string apiResponse = await response.Content.ReadAsStringAsync();
                laLista = JsonConvert.DeserializeObject<List<GestorDeRestaurante.Model.MenuIngredientes>>(apiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ViewBag.IdMenu=id;  
            return View(laLista);
        }

        // GET: IngredienteDelMenuController/Create
        public async Task<IActionResult> Create(int idMenu)
        {
            List<Model.Ingredientes> laListaDeIngredientes;
            List<Model.Medidas> laListaDeMedidas;

            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync("https://localhost:7071/api/IngredientesDelMenu/ObtengaLaListaDeIngredientes");
                string apiResponse = await response.Content.ReadAsStringAsync();
                laListaDeIngredientes = JsonConvert.DeserializeObject<List<Model.Ingredientes>>(apiResponse);

                var httpClient2 = new HttpClient();
                var responseMedidas = await httpClient.GetAsync("https://localhost:7071/api/IngredientesDelMenu/ObtengaLaListaDeMedidas");
                string apiResponseMedidas = await responseMedidas.Content.ReadAsStringAsync();
                laListaDeMedidas = JsonConvert.DeserializeObject<List<Model.Medidas>>(apiResponseMedidas);
            }
            catch (Exception)
            {
                throw;
            }

            ViewBag.idMenu = idMenu;    
            ViewBag.laListaDeIngredientes = laListaDeIngredientes;
            ViewBag.laListaDeMedidas = laListaDeMedidas;

            return View();
        }

        // POST: IngredienteDelMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string idIngrediente, string idMedida, Model.MenuIngredientes menuIngrediente)
        {
            int ElIdDelIngrediente = Int32.Parse(idIngrediente);
            int ElIdDeLaMedida= Int32.Parse(idMedida);

            try
            {
                GestorDeRestaurante.Model.MenuIngredientes elIngredienteAsociado = new Model.MenuIngredientes();
                
                elIngredienteAsociado.Id_Menu = 1;
                elIngredienteAsociado.Id_Ingredientes = ElIdDelIngrediente;
                elIngredienteAsociado.Cantidad = menuIngrediente.Cantidad;
                elIngredienteAsociado.Id_Medidas = ElIdDeLaMedida;
                elIngredienteAsociado.ValorAproximado = menuIngrediente.ValorAproximado;

                var httpClient = new HttpClient();

                string json = JsonConvert.SerializeObject(elIngredienteAsociado);

                var buffer = System.Text.Encoding.UTF8.GetBytes(json);

                var byteContent = new ByteArrayContent(buffer);

                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                await httpClient.PostAsync("https://localhost:7071/api/IngredientesDelMenu/AsocieUnIngrediente", byteContent);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IngredienteDelMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IngredienteDelMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IngredienteDelMenuController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IngredienteDelMenuController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

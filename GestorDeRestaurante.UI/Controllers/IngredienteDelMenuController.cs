using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GestorDeRestaurante.UI.Controllers
{
    public class IngredienteDelMenuController : Controller
    {
        // GET: IngredienteDelMenuController
        public async Task<IActionResult> Index()
        {
            List<Model.MenuIngredientes> laLista;
            try
            {
                var httpClient = new HttpClient();

                var response = await httpClient.GetAsync("https://localhost:7071/api/IngredientesDelMenu/ObtengaLaListaDelMenuParaIngredientes");
                string apiResponse = await response.Content.ReadAsStringAsync();
                laLista = JsonConvert.DeserializeObject<List<GestorDeRestaurante.Model.MenuIngredientes>>(apiResponse);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(laLista);
        }

        // GET: IngredienteDelMenuController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: IngredienteDelMenuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IngredienteDelMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

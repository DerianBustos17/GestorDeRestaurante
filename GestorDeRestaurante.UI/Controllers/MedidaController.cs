using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorDeRestaurante.UI.Controllers
{
    public class MedidaController : Controller
    {
        // GET: MedidaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MedidaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MedidaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedidaController/Create
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

        // GET: MedidaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MedidaController/Edit/5
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

        // GET: MedidaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MedidaController/Delete/5
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

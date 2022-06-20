using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorDeRestaurante.UI.Controllers
{
    public class PlatilloDelMenuController : Controller
    {
        // GET: PlatilloDelMenuController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PlatilloDelMenuController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PlatilloDelMenuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlatilloDelMenuController/Create
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

        // GET: PlatilloDelMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PlatilloDelMenuController/Edit/5
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

        // GET: PlatilloDelMenuController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PlatilloDelMenuController/Delete/5
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

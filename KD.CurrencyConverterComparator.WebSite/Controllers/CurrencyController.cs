using KD.CurrencyConverterComparator.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KD.CurrencyConverterComparator.WebSite.Controllers
{
    public class CurrencyController : Controller
    {
        // GET: Currency
        public ActionResult Index()
        {
            return View(new ModelCurrenciesDownloader());
        }

        // GET: Currency/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Currency/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Currency/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Currency/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Currency/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Currency/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Currency/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
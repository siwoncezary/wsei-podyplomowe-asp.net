using Microsoft.AspNetCore.Mvc;
using Z2.Models;

namespace Z2.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }

        // GET: BookController
        public IActionResult Index()
        {
            return View(_service.FindAll());
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookController/Create, wyświetlanie formularza tworzenia nowej książki
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create, odebranie danych nowej książki
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book model)
        {
            if (ModelState.IsValid)
            {
                _service.Add(model);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookController/Edit/5
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

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookController/Delete/5
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
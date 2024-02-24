using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            return View(_service.FindById(id));
        }

        // GET: BookController/Create, wyświetlanie formularza tworzenia nowej książki
        public ActionResult Create()
        {
            ViewBag.Authors = _service.FindAllAuthors()
                .Select(a => new SelectListItem()
                {
                    Text = $"{a.FirstName} {a.LastName} (liczba książek: {a.Books[0].Author?.Books[1]})",
                    Value = $"{a.Id}",
                    Selected = a.Id == 1,
                }).ToList();
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
            return View(_service.FindById(id));
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Book model)
        {
            if (ModelState.IsValid)
            {
                _service.Edit(model);
                return RedirectToAction(nameof(Index));
            }
            return View();
            
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_service.FindById(id));
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Book model) 
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
            
        }
    }
}
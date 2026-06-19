using Lesson3_CNLTWeb.Data;
using Lesson3_CNLTWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lesson3_CNLTWeb.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _repo;

        public BookController(BookRepository repo)
        {
            _repo = repo;
        }

        // ĐỌC (READ)
        public IActionResult Index()
        {
            return View(_repo.GetAll());
        }

        // XEM CHI TIẾT (DETAILS)
        public IActionResult Details(int id)
        {
            // Gọi hàm GetById từ code mẫu của thầy để lấy thông tin sách
            var book = _repo.GetById(id);
            if (book == null)
            {
                return NotFound(); // Trả về 404 nếu không tìm thấy sách trong DB
            }
            return View(book);
        }
        // THÊM (CREATE)
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Book book)
        {
            _repo.Add(book);
            return RedirectToAction("Index");
        }

        // SỬA (UPDATE)
        public IActionResult Edit(int id)
        {
            var book = _repo.GetById(id);
            if (book == null) return NotFound();
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            _repo.Update(book);
            return RedirectToAction("Index");
        }

        // XÓA (DELETE)
        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
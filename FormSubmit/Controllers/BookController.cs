using Microsoft.AspNetCore.Mvc;
using FormSubmit.Models;
using System.Collections.Generic;
using System.Linq;

namespace FormSubmit.Controllers
{
    public class BookController : Controller
    {
        // Khởi tạo danh sách sách mẫu
        private static List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Name = "Clean Code", Price = 20 },
            new Book { Id = 2, Name = "ASP.NET MVC", Price = 15 },
            new Book { Id = 3, Name = "Design Pattern", Price = 25 }
        };

        [HttpGet]
        public IActionResult Index()
        {
            return View(_books);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound("Không tìm thấy sách!");
            }
            return View(book);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book model)
        {
            // Kiểm tra tính hợp lệ qua ModelState (Data Annotation)
            if (!ModelState.IsValid)
            {
                // Nếu dữ liệu vi phạm điều kiện, trả lại View kèm thông báo lỗi
                return View(model);
            }

            model.Id = _books.Any() ? _books.Max(b => b.Id) + 1 : 1;
            _books.Add(model);

            // Ghi thông báo thành công và quay lại danh sách
            TempData["SuccessMessage"] = "Thêm thành công";
            return RedirectToAction("Index");
        }
    }
}
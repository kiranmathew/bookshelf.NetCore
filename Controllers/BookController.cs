using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coresampleBookShefl.Model;
using Microsoft.AspNetCore.Mvc;

namespace coresampleBookShefl.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var allData = _db.Book.ToList();
            return Json(new { data = allData });
        }
    }
}

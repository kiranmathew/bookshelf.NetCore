using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coresampleBookShefl.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace coresampleBookShefl.Pages.BookList
{
    public class CreateModel : PageModel
    {
        public readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Book Books { get; set; }

        public void OnGet()
        {
            
        }
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                await _db.Book.AddAsync(Books);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }

        }
    }
}

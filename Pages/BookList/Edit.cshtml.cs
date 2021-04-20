using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coresampleBookShefl.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace coresampleBookShefl.Pages.BookList
{
    public class EditModel : PageModel
    {
        public readonly ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Book Books { get; set; }
        public async Task OnGet(int Id)
        {
            Books = await _db.Book.FindAsync(Id);
            
            //return RedirectToPage("Index");
        }
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var BookFromDb = await _db.Book.FindAsync(Books.Id);
                BookFromDb.Name = Books.Name;
                BookFromDb.Author = Books.Author;
                BookFromDb.ISBN = Books.ISBN;
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
        

        
    }
}

using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Student Student { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db; 
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _db.Students.Add(Student);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}

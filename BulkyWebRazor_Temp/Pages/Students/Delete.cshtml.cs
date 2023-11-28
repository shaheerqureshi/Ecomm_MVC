using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Students
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Student Student { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int? id)
        {
            if (id != null || id != 0)
            {
                Student = _db.Students.Find(id);

            }
        }


        public IActionResult OnPost()
        {
            Student? student = _db.Students.Find(Student.id);
            if (student == null)
            {
                return NotFound();
            }
            
            _db.Students.Remove(student);
            _db.SaveChanges();
                //TempData["success"] = "Student updated successfully";
            return RedirectToPage("Index");
         

        }
    }
}

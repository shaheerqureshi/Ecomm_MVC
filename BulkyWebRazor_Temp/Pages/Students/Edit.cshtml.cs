using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Students
{
    [BindProperties]
    public class EditModel : PageModel
    {
        
        private readonly ApplicationDbContext _db;
        public Student Student { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int? id)
        {
            if (id != null || id != 0)
            {
               Student =  _db.Students.Find(id);
                
            }
        }


        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                _db.Students.Update(Student);
                _db.SaveChanges();
                //TempData["success"] = "Student updated successfully";
                return RedirectToPage("Index");
            }
            return Page();
           
        }
    }
}

using BulkyWebRazor.Data;
using BulkyWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public List<Category> catList { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
            
        }
        public void OnGet()
        {
            catList = _db.CategoriesRazorTbl.ToList();
        }
    }
}

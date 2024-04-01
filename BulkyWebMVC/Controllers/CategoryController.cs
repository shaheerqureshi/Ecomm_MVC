using Bulk.DataAccess.Data;
using Bulk.DataAccess.Repository.IRepository;
using Bulk.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Bulk.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository db)
        {
            _categoryRepo = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _categoryRepo.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name and display order cannopt be same");
            }
            if(ModelState.IsValid)
            {
                _categoryRepo.Add(obj);
                _categoryRepo.Save();
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
            
            
        }
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Category? catfromDb = _categoryRepo.Get(u=>u.Id == id);
            //Category? catfromDb1 = _db.Categories.FirstOrDefault(u=>u.Id ==id);
            //Category? catfromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if (catfromDb == null)
            {
                return NotFound();
            }
            return View(catfromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name and display order cannopt be same");
            }
            if(ModelState.IsValid)
            {
                _categoryRepo.Update(obj);
                _categoryRepo.Save();
                TempData["success"] = "Category Updated Successfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
            
            
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? catfromDb = _categoryRepo.Get(u => u.Id == id);
            //Category? catfromDb1 = _db.Categories.FirstOrDefault(u=>u.Id ==id);
            //Category? catfromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if (catfromDb == null)
            {
                return NotFound();
            }
            return View(catfromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? obj = _categoryRepo.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _categoryRepo.Remove(obj);
            _categoryRepo.Save();
                return RedirectToAction("Index", "Category");
        }
    }
}

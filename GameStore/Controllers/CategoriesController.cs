using GameStore.Interfaces;
using GameStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategory _categories;

        public CategoriesController(ICategory categories)
        {
            _categories = categories;
        }
        public IActionResult Index()
        {
            return View(_categories.GetAllCategories());
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            _categories.AddCategory(category);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult EditCategory(long id)
        {
            ViewBag.Editid = id;
            return View(nameof(Index), _categories.GetAllCategories());
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            _categories.UpdateCategory(category);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult DeleteCategory(Category category)
        {
            _categories.DeleteCategory(category);
            return RedirectToAction(nameof(Index));
        }
    }

}

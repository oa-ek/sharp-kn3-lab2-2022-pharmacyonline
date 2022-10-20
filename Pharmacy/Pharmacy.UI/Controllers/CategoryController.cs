using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Repos;
using XStats.Core;

namespace Pharmacy.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly PharmacyDbContext _dbcontext;
        private readonly CategoryRepository _categoryRepository;
        private readonly SubCategoryRepository _subcategoryRepository;
        //private readonly 

        public CategoryController(CategoryRepository categoryRepository, SubCategoryRepository subcategoryRepository)
        {
            _categoryRepository = categoryRepository;
            _subcategoryRepository = subcategoryRepository;
        }
        public IActionResult Index()
        {
            return View(_categoryRepository.GetAllCategory());
        }
        [HttpGet]
        public IActionResult CategoryCatalog(int id)
        {
            ViewData["id"] = id;
            var category = _categoryRepository.GetCategory(id);
            ViewData["category"] = category;
            return View(_subcategoryRepository.GetAllSubCategoryFromCategory(id));
        }

    }
}

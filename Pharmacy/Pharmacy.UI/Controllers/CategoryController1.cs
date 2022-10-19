using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Repos;
using XStats.Core;

namespace Pharmacy.UI.Controllers
{
    public class CategoryController1 : Controller
    {
        private readonly PharmacyDbContext _dbcontext;
        private readonly CategoryRepository _categoryRepository;
        //private readonly 

        public CategoryController1(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CategoryCatalog(int id)
        {
            ViewData["id"] = id;
            var category = _dbcontext.SubCategory.First(x => x.SubCategoryId == id);
            ViewData["category"] = category;
            return View(_dbcontext.Medicaments.Where(x => x.SubCategory == category).ToList());
        }
    }
}

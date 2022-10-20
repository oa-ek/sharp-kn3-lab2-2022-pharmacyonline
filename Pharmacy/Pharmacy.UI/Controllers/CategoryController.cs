using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Core;
using Pharmacy.Repos;

namespace Pharmacy.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly PharmacyDbContext _dbcontext;
        private readonly CategoryRepository _categoryRepository;
        private readonly SubCategoryRepository _subcategoryRepository;
        private readonly CatalogRepository _catalogRepository;
        private readonly MedicamentsRepository _medicamentsRepository;
        private readonly SubCategoryMedicamentsRepository _subcategorymedicamentsRepository;
        //private readonly 

        public CategoryController(CategoryRepository categoryRepository, SubCategoryRepository subcategoryRepository, 
            CatalogRepository catalogRepository, MedicamentsRepository medicamentsRepository, SubCategoryMedicamentsRepository subcategorymedicamentsRepository)
        {
            _categoryRepository = categoryRepository;
            _subcategoryRepository = subcategoryRepository;
            _catalogRepository = catalogRepository;
            _medicamentsRepository = medicamentsRepository;
            _subcategorymedicamentsRepository = subcategorymedicamentsRepository;
        }
        public IActionResult Index(int id)
        {
            ViewData["id"] = id;
            var catalog = _catalogRepository.GetCatalog(id);
            ViewData["catalog"] = catalog;
            return View(_categoryRepository.GetCategoryCatalogWithSub(id));
        }
        [HttpGet]
        public IActionResult CategoryProducts(int id)
        {
            ViewData["id"] = id;
            var subcategory = _subcategoryRepository.GetSubCategory(id);
            ViewData["category"] = subcategory.Name;
            var medicaments = _subcategorymedicamentsRepository.GetAllMedicamentsFromSubCategory(subcategory.SubCategoryId);
            return View(_medicamentsRepository.ListMedicaments(medicaments));
        }
        [HttpGet]
        public IActionResult CategoryAllProducts(int id)
        {
            var category = _categoryRepository.GetCategory(id);
            ViewData["category"] = category.Name;
            var subcategories = _subcategoryRepository.GetAllSubCategoryFromCategory(id);
            List<SubCategoryMedicaments> medicaments=new List<SubCategoryMedicaments>();
            foreach (var ct in subcategories)
            {
                medicaments = _subcategorymedicamentsRepository.GetAllMedicamentsFromSubCategory(ct.SubCategoryId);
            }
            return View("CategoryControl",_medicamentsRepository.ListMedicaments(medicaments));
        }
        [HttpGet]
        public IActionResult SubCategory(int id)
        {
            ViewData["id"] = id;
            var subcategory = _subcategoryRepository.GetSubCategory(id);
            ViewData["subcategory"] = subcategory;
            return View(_subcategoryRepository.GetAllSubCategoryFromCategory(id));
        }
        [HttpGet]
        public IActionResult DetailsMedicament(int id)
        {
            return View("Details", _medicamentsRepository.InfoMedicaments(id));
        }

    }
}

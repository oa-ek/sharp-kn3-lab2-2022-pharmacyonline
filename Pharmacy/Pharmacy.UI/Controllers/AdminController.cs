using Microsoft.AspNetCore.Mvc;
using Pharmacy.Core;
using Pharmacy.Repos;
using Pharmacy.Repos.Dto;

namespace Pharmacy.UI.Controllers
{
    public class AdminController : Controller
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly SubCategoryRepository _subcategoryRepository;
        private readonly CatalogRepository _catalogRepository;
        private readonly MedicamentsRepository _medicamentsRepository;
        private readonly SubCategoryMedicamentsRepository _subcategorymedicamentsRepository;
        //private readonly 

        public AdminController(CategoryRepository categoryRepository, SubCategoryRepository subcategoryRepository,
            CatalogRepository catalogRepository, MedicamentsRepository medicamentsRepository, SubCategoryMedicamentsRepository subcategorymedicamentsRepository)
        {
            _categoryRepository = categoryRepository;
            _subcategoryRepository = subcategoryRepository;
            _catalogRepository = catalogRepository;
            _medicamentsRepository = medicamentsRepository;
            _subcategorymedicamentsRepository = subcategorymedicamentsRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Categories()
        {
            return View(await _categoryRepository.GetAllCategory());
        }

        // EDIT CATEGORY

        [HttpGet]
        public async Task<IActionResult> EditCategory(int id)
        {
            ViewBag.Catalog = await _catalogRepository.GetAllCatalog();
            return View(await _categoryRepository.GetCategory(id));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditCategory(Category model)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.UpdateAsync(model);
            }
            return RedirectToAction("Categories"); ;
        }

        // DELETE CATEGORY

        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryRepository.GetCategory(id);
            ViewBag.Subcategory = await _subcategoryRepository.GetAllSubCategoryFromCategory(category);
            return View(await _categoryRepository.GetCategory(id));
        }

        [HttpPost, ActionName("DeleteCategory")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryRepository.GetCategory(id);
            ViewBag.Subcategory = await _subcategoryRepository.GetAllSubCategoryFromCategory(category);
            var subcategories = ViewBag.Subcategory;
            if (subcategories != null) 
            {
                await _categoryRepository.Delete(id);
                return RedirectToAction("Categories");
            }
            return View(category);            
        }

        // CREATE CATEGORY
        [HttpGet]
        public async Task<IActionResult> CreateCategoryAsync()
        {
            ViewBag.Catalog = await _catalogRepository.GetAllCatalog();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreateCategory(Category model, string[] catalog)
        {
            var catalogs = new List<Catalog>();
            foreach (var item in catalog)
            {
                catalogs.Add(await _catalogRepository.GetCatalogS(item)); 
            }
            if (ModelState.IsValid)
            {
                Category ct = await _categoryRepository.CreateCategory(model.Name, catalogs);
                //await _categoryRepository.AddToCatalog(ct, catalog);
                return RedirectToAction("Categories");
            }
            return View(model);
        }
    }
}

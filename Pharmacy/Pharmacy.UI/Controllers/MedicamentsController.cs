
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Core;
using Pharmacy.Repos;
using Pharmacy.Repos.Dto;

namespace Pharmacy.UI.Controllers
{
    public class MedicamentsController : Controller
    {
        private readonly PharmacyDbContext _dbcontext;
        private readonly CategoryRepository _categoryRepository;
        private readonly SubCategoryRepository _subcategoryRepository;
        private readonly CatalogRepository _catalogRepository;
        private readonly MedicamentsRepository _medicamentsRepository;
        private readonly SubCategoryMedicamentsRepository _subcategorymedicamentsRepository;
        //private readonly 

        public MedicamentsController(CategoryRepository categoryRepository, SubCategoryRepository subcategoryRepository,
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
        public async Task<IActionResult> DetailsMedicament(int id)
        {
            return View("Details", await _medicamentsRepository.InfoMedicaments(id));
        }

        // EDIT       

        public async Task<IActionResult> Edit(int id)
        {
            var med = await _medicamentsRepository.GetMedicament(id);
            ViewBag.Subcategory = await _subcategoryRepository.GetAllSubCategory();
            ViewBag.SubcategoryOfMed = await _subcategorymedicamentsRepository.GetSubCategoriesMedicament(med.MedicamentsId);
            ViewBag.returnUrl = Request.Headers["Referer"].ToString();
            return View(med);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(Medicaments model, string returnUrl, string[] subcategoriesofMed)
        {
            var subcategory = new List<SubCategory>();
            foreach(var s in subcategoriesofMed)
            {
                subcategory.Add(await _subcategoryRepository.GetSubCategoryS(s));
            }
            if (ModelState.IsValid)
            {
                await _medicamentsRepository.UpdateAsync(model, subcategory);
            }
            ViewBag.Subcategory = await _subcategoryRepository.GetAllSubCategory();
            return Redirect(returnUrl); ;
        }

        // DELETE

        public async Task<IActionResult> Delete(int id)
        {
            return View();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _medicamentsRepository.DeleteMedicament(id);
            return RedirectToPage("CategoryProducts");
        }

        // CREATE

        [HttpGet]
        public async Task<IActionResult> CreateAsync()
        {
            ViewBag.Subcategory = await _subcategoryRepository.GetAllSubCategory();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Medicaments model)
        { 
            ViewBag.Subcategory = await _subcategoryRepository.GetAllSubCategory();
            var listsubcategory = ViewBag.Subcategory;
            if (ModelState.IsValid)
            {
                Medicaments md = await _medicamentsRepository.Create(model.Name, model.Code, model.Price, model.ReleaseForm, model.Dosage, model.PhotoPath, model.Description);
                await _subcategorymedicamentsRepository.AddToSubCategory(md, listsubcategory);
                return RedirectToAction("DetailsMedicamemt", "Medicaments", new { id = md.MedicamentsId });
            }
            return View(model);
        }

    }
}

using Microsoft.EntityFrameworkCore;
using Pharmacy.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pharmacy.Repos
{
    public class SubCategoryMedicamentsRepository
    {
        public readonly PharmacyDbContext _ctx;

        public SubCategoryMedicamentsRepository(PharmacyDbContext ctx)
        {
            _ctx = ctx;
        }
        public List<SubCategoryMedicaments> GetAllMedicamentsFromCategory(int id)
        {
            return _ctx.SubCategoryMedicaments.Include(x => x.SubCategory).Include(x => x.Medicaments).Where(x => x.SubCategoryId == id).ToList();
        }
        public List<SubCategoryMedicaments> GetAllMedicamentsFromSubCategory(int id)
        {
            return _ctx.SubCategoryMedicaments.Include(x=>x.Medicaments).Where(x=>x.SubCategoryId==id).ToList();
        }
        public List<SubCategoryMedicaments> GetAllSubCategory(int id)
        {
            return _ctx.SubCategoryMedicaments.ToList();
        }
    }
}

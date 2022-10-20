using Pharmacy.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStats.Core;

namespace Pharmacy.Repos
{
    public class SubCategoryRepository
    {
        public readonly PharmacyDbContext _ctx;

        public SubCategoryRepository(PharmacyDbContext ctx)
        {
            _ctx = ctx;
        }
        public SubCategory GetSubCategory(int id)
        {
            return _ctx.SubCategory.Find(id);
        }
        public List<SubCategory> GetAllSubCategory()
        {
            return _ctx.SubCategory.ToList();
        }
        public List<SubCategory> GetAllSubCategoryFromCategory(int id)
        {
            return _ctx.SubCategory.Where(x=>x.Category.Id == id).ToList();
        }
    }
}

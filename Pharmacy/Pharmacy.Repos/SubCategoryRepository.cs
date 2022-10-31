using Microsoft.EntityFrameworkCore;
using Pharmacy.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pharmacy.Repos
{
    public class SubCategoryRepository
    {
        public readonly PharmacyDbContext _ctx;

        public SubCategoryRepository(PharmacyDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<SubCategory> GetSubCategory(int id)
        {
            return await _ctx.SubCategory.FirstAsync(x=>x.SubCategoryId == id);
        }
        public async Task<List<SubCategory>> GetAllSubCategory()
        {
            return await _ctx.SubCategory.Include(x => x.Category).ToListAsync();
        }
        public async Task<List<SubCategory>> GetAllSubCategoryFromCategory(Category id)
        {
            return await _ctx.SubCategory.Include(x => x.Category).Where(x=>x.Category.Id == id.Id).ToListAsync();
        }
        public async Task<SubCategory> GetSubCategoryS(string name)
        {
            return await _ctx.SubCategory.FirstAsync(x=>x.Name == name);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Pharmacy.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Repos
{
    public class CategoryRepository
    {
        public readonly PharmacyDbContext _ctx;

        public CategoryRepository(PharmacyDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Category> GetCategory(int id)
        {
            return await _ctx.Category.FirstAsync(x => x.Id == id);
        }
        public async Task<List<Category>> GetAllCategory()
        {
            return await _ctx.Category.Include(x=>x.SubCategory).Include(x=>x.Catalog).ToListAsync();
        }
        public List<Category> GetCategoryCatalogWithSub(int id)
        {
            return _ctx.Category.Include(x => x.SubCategory).Where(x=>x.Catalog.Id==id).ToList();
        }
    }
}

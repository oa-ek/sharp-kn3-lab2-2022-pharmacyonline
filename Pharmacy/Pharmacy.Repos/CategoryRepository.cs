using Pharmacy.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStats.Core;

namespace Pharmacy.Repos
{
    public class CategoryRepository
    {
        public readonly PharmacyDbContext _ctx;

        public CategoryRepository(PharmacyDbContext ctx)
        {
            _ctx = ctx;
        }
        public Category GetCategory(int id)
        {
            return _ctx.Category.Find(id);
        }
        public List<Category> GetAllCategory()
        {
            return _ctx.Category.ToList();
        }
    }
}

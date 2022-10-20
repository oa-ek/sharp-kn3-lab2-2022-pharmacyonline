using Microsoft.EntityFrameworkCore;
using Pharmacy.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStats.Core;

namespace Pharmacy.Repos
{
    public class CatalogRepository
    {
        public readonly PharmacyDbContext _ctx;

        public CatalogRepository(PharmacyDbContext ctx)
        {
            _ctx = ctx;
        }
        public Catalog GetCategory(int id)
        {
            return _ctx.Catalog.Find(id);
        }
        public List<Catalog> GetAllCatalog()
        {
            return _ctx.Catalog.Include(x=>x.Category).ToList();
        }
    }
}

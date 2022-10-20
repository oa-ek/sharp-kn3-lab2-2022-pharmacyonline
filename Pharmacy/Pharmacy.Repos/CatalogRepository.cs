using Microsoft.EntityFrameworkCore;
using Pharmacy.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pharmacy.Repos
{
    public class CatalogRepository
    {
        public readonly PharmacyDbContext _ctx;

        public CatalogRepository(PharmacyDbContext ctx)
        {
            _ctx = ctx;
        }
        public Catalog GetCatalog(int id)
        {
            return _ctx.Catalog.Find(id);
        }
        public List<Catalog> GetAllCatalog()
        {
            return _ctx.Catalog.ToList();
        }
    }
}

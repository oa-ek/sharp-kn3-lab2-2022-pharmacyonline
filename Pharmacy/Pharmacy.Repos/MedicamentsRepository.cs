using Pharmacy.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStats.Core;

namespace Pharmacy.Repos
{
    public class MedicamentsRepository
    {
        public readonly PharmacyDbContext _ctx;

        public MedicamentsRepository(PharmacyDbContext ctx)
        {
            _ctx = ctx;
        }
        public Medicaments GetMedicaments(int id)
        {
            return _ctx.Medicaments.Find(id);
        }
        public List<Medicaments> GetAllMedicaments()
        {
            return _ctx.Medicaments.ToList();
        }
    }
}

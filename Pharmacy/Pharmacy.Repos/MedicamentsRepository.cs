using Microsoft.EntityFrameworkCore;
using Pharmacy.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<Medicaments> ListMedicaments(List<SubCategoryMedicaments> medicaments)
        {
            List<Medicaments> listmedicaments = new List<Medicaments>();
            foreach (var md in medicaments)
            {
                var medics = _ctx.Medicaments.First(x => x.MedicamentsId == md.MedicamentsId);
                listmedicaments.Add(medics);
            }
            return listmedicaments;
        }
        public List<Medicaments> GetAllMedicaments()
        {
            return _ctx.Medicaments.ToList();
        }
        public List<Medicaments> GetAllMedicamentsFromCategory(SubCategory id)
        {
            return _ctx.Medicaments.Include(x=>x.SubCategoryMedicaments).Where(x=>x.SubCategoryMedicaments==id).ToList();
        }
        public Medicaments InfoMedicaments(int id)
        {
            return _ctx.Medicaments.Include(x=>x.Brend).Include(x => x.Country).Include(x => x.ProductLine).Include(x => x.SubCategoryMedicaments).First(x => x.MedicamentsId==id);
        }
    }
}

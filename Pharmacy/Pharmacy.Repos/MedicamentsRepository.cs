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
        public async Task<Medicaments> GetMedicament(int id)
        {
            return await _ctx.Medicaments.Include(x=>x.SubCategoryMedicaments).FirstAsync(x=>x.MedicamentsId == id);
        }


        public async Task<List<Medicaments>> ListMedicaments(List<SubCategoryMedicaments> medicaments)
        {
            List<Medicaments> listmedicaments = new List<Medicaments>();
            foreach (var md in medicaments)
            {
                var medics = await _ctx.Medicaments.FirstAsync(x => x.MedicamentsId == md.MedicamentsId);
                listmedicaments.Add(medics);
            }
            return listmedicaments;
        }


        public async Task<List<Medicaments>> GetAllMedicaments()
        {
            return await _ctx.Medicaments.ToListAsync();
        }
        public async Task<List<Medicaments>> GetAllMedicamentsFromCategory(SubCategory id)
        {
            return await _ctx.Medicaments.Include(x=>x.SubCategoryMedicaments).Where(x=>x.SubCategoryMedicaments==id).ToListAsync();
        }
        public async Task<Medicaments> InfoMedicaments(int id)
        {
            return await _ctx.Medicaments.Include(x=>x.Brend).Include(x => x.Country).Include(x => x.ProductLine).Include(x => x.SubCategoryMedicaments).FirstAsync(x => x.MedicamentsId==id);
        }


        public async Task DeleteMedicament(int id)
        {
            var medicament = await GetMedicament(id);
            _ctx.Medicaments.Remove(medicament);
            await _ctx.SaveChangesAsync();
        }
    }
}

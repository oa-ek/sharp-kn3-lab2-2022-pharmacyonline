using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStats.Core;

namespace Pharmacy.Core
{
    public class Medicaments
    {
        /*public Medicaments()
        {
            this.SubCategory = new HashSet<SubCategory>();
        }*/
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicamentsId { get; set; }
        public string? Name { get; set; }
        public string Code { get; set; }
        public int Price { get; set; }
        public string? PhotoPath { get; set; }
        public ProductLine? ProductLine { get; set; }
        public Brend? Brend { get; set; }
        public string ReleaseForm { get; set; }
        public string Dosage { get; set; }
        public Country? Country { get; set; }
        public virtual ICollection<SubCategoryMedicaments>? SubCategoryMedicaments { get; set; }

    }
}

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
        public virtual ICollection<SubCategoryMedicaments>? SubCategoryMedicaments { get; set; }

    }
}

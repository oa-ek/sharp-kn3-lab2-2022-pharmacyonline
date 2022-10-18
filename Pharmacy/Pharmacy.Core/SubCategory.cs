using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core
{
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public Category? Category { get; set; }
        public virtual ICollection<Medicaments>? Medicaments { get; set; }
    }
}

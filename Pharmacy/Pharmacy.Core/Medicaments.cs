using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core
{
    public class Medicaments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicamentsId { get; set; }        
        public string? Name { get; set; }
        [Display(Name = "Артикул")]
        public string Code { get; set; }
        [Display(Name = "Ціна")]
        public double Price { get; set; }
        [Display(Name = "Photos")]
        public string PhotoPath { get; set; }
        [Display(Name = "Лінійка продуктів")]
        public ProductLine? ProductLine { get; set; }
        [Display(Name = "Бренд")]
        public Brend? Brend { get; set; }
        [Display(Name = "Форма випуску")]
        public string ReleaseForm { get; set; }
        [Display(Name = "Дозування")]
        public string Dosage { get; set; }
        [Display(Name = "Країна")]
        public Country? Country { get; set; }
        [Display(Name = "Опис")]
        public string? Description { get; set; }
        public virtual ICollection<SubCategoryMedicaments>? SubCategories { get; set; } = new HashSet<SubCategoryMedicaments>();

    }
}

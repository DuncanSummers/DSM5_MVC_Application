using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM5.Data
{
    public class Disorder
    {
        [Key]
        public int DisorderID { get; set; }
        [Required]
        [Display(Name = "ICD-10-CM")]
        public string ICD { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string DisorderName { get; set; }
        [Required]
        public virtual ICollection<DisorderSymptom> Symptoms { get; set; } = new List<DisorderSymptom>();
        public virtual ICollection<Comorbidity> Comorbidities { get; set; } = new List<Comorbidity>();
    }
}

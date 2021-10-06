using DSM5.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM5.Models
{
    public class DisorderCreate
    {
        [Required]
        [DisplayName("ICD-10-CM")]
        public string ICD { get; set; }
        [Required]
        [ForeignKey(nameof(Category))]
        public string Category { get; set; }
        [Required]
        public string DisorderName { get; set; }
        public virtual ICollection<DisorderSymptom> Symptoms { get; set; }
        public virtual ICollection<Comorbidity> Comorbidities { get; set; }
    }
}

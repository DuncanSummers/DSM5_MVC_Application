using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM5.Data
{
    public class DisorderSymptom
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [ForeignKey(nameof(Disorder))]
        public int DisorderID { get; set; }
        public virtual Disorder Disorder { get; set; }
        [Required]
        [ForeignKey(nameof(Symptom))]
        public int SymptomID { get; set; }
        public virtual Symptom Symptom { get; set; }

    }
}

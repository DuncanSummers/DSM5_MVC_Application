using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM5.Data
{
    public class Comorbidity
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey(nameof(Disorder))]
        public int BaseID { get; set; }
        public virtual Disorder Disorder { get; set; }
        [ForeignKey(nameof(Comorbidities))]
        public int ComorbidityID { get; set; }
        public virtual Disorder Comorbidities { get; set; }
    }
}

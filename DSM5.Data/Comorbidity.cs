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
        [ForeignKey(nameof(Disorder))]
        public int BaseID { get; set; }
        public virtual Disorder Disorder { get; set; }
        [ForeignKey(nameof(Comorbid))]
        public int ComorbidityID { get; set; }
        public virtual Disorder Comorbid { get; set; }

    }
}

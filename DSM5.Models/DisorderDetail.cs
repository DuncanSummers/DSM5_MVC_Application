using DSM5.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM5.Models
{
    public class DisorderDetail
    {
        public int DisorderID { get; set; }
        public string ICD { get; set; }
        public string Category { get; set; }
        public string DisorderName { get; set; }
        public ICollection<DisorderSymptom> Symptoms { get; set; }
        public ICollection<Comorbidity> Comorbidities { get; set; }
    }
}

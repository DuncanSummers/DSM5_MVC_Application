using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM5.Data
{
    public class Symptom
    {
        [Key]
        public int SymptomID { get; set; }
        [Required]
        public string Description { get; set; }
    }
}

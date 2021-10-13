using DSM5.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM5.Models
{
    public class DisorderSymptomCreate
    {
        public int DisorderID { get; set; }
        public int SymptomID { get; set; }

    }
}

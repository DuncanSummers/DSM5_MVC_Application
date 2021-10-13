using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM5.Models
{
    public class DisorderSymptomListItem
    {
        [Key]
        public int ID { get; set; }
        public int DisorderID { get; set; }
        public int SymptomID { get; set; }

    }
}

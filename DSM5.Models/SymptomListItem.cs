using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM5.Models
{
    public class SymptomListItem
    {
        [Key]
        public int SymptomID { get; set; }
        public string Description { get; set; }

    }
}

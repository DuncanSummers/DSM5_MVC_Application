using DSM5.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM5.Models
{
    public class ComorbidityCreate
    {
        [ForeignKey(nameof(Disorder))]
        public int BaseID { get; set; }
        [ForeignKey(nameof(Disorder))]
        public int ComorbidityID { get; set; }
    }
}

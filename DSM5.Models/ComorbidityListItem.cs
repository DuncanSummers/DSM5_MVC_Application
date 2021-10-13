using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM5.Models
{
    public class ComorbidityListItem
    {
        [Key]
        public int BaseID { get; set; }
        public int ComorbidityID { get; set; }
    }
}
